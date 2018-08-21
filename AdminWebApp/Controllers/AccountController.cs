using AdminWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shared;
using SMS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{

    [Authorize]
    public class AccountController : ApplicationBaseController
    {
        ApplicationDbContext context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        readonly EmailTemplate email = new EmailTemplate();
        readonly SMSUtility SMS = new SMSUtility();


        public AccountController()
        {
            context = new ApplicationDbContext();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Before Login email should be verified

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var userDetail = UserManager.FindByEmail(model.Email);
                    if (!UserManager.IsEmailConfirmed(userDetail.Id))
                    {
                        ViewBag.UserId = userDetail.Id;
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        return View("ConfirmYourEmail");
                    }
                    SetUserImage(userDetail);
                    SMS.SendByTwilioWhatsApp(userDetail.PhoneNumber, "Welcome " + userDetail.FirstName + ", You have succesfully logged in!");
                    return RedirectToAction("Dashboard", "Home");//RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        protected void SetUserImage(ApplicationUser userDetail)
        {
            if (userDetail != null)
            {
                if (userDetail.UserPhoto != null)
                {
                    Session["UserPhoto"] = "data:image/png;base64," + Convert.ToBase64String(userDetail.UserPhoto);
                }
                else
                {
                    Session["UserPhoto"] = "/Images/UserProfileImages/noImgSmall.png";
                }
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> ConfirmYourEmail(string UserId)
        {
            try
            {
                if (UserId == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(UserId);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = UserId, code }, protocol: Request.Url.Scheme);
                var userDetail = UserManager.FindById(UserId);
                StringBuilder st = new StringBuilder();
                st.Append("<!DOCTYPE html><html><head><meta charset='utf - 8'/><title>Confirm Email</title></head><body><div style='width: 650px; min - height:420px; margin: 0 auto; padding - top:1px; background - color:#1d8e07'><div style='height:auto;margin-left:8px;width:642px;min-height:420px;background-color:#fff'><div style='min-height:250px;padding:30px 35px 30px;margin:0;line-height:1.5em;word-wrap:break-word'><br /><div>Hi " + userDetail.FirstName + ", <br></div><div><br></div><div>Please confirm below link to complete your request that you submitted on our website.<br></div><div><br></div>");
                st.Append("<div><a style='border: 1px solid #1d8e07;background:#1d8e07;display:inline-block;padding:7px 15px;text-decoration:none;color:#fff' href=\"" + callbackUrl + "\" target='_blank'>Click here to confirm</a> <br></div>");
                st.Append("<div><br></div><br /><br /><br /><div>Thanks!<br></div><div><br></div><div>BASE Institution Team,<br></div></div></div></div></body></html>");
                await UserManager.SendEmailAsync(UserId, "Confirm your account", st.ToString());
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    var userDetail = UserManager.Users.FirstOrDefault();
                    SetUserImage(userDetail);
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
                context = new ApplicationDbContext();
                ViewBag.Count = UserManager.Users.Count();
                ViewBag.UsersWithRole = (from user in context.Users
                                         select new
                                         {
                                             UserId = user.Id,
                                             Username = user.UserName,
                                             user.Email,
                                             RoleNames = (from userRole in user.Roles
                                                          join role in context.Roles on userRole.RoleId
                                                          equals role.Id
                                                          select role.Name).ToList()
                                         }).ToList().Select(p => new UsersInRoleModel()

                                         {
                                             UserId = p.UserId,
                                             UserName = p.Username,
                                             Email = p.Email,
                                             Role = string.Join(",", p.RoleNames)
                                         });
                return View();
            }
            else
            {
                return RedirectToAction("AuthorizationError", "Account");
            }

        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Exclude = "UserPhoto")]RegisterViewModel model)
        {
            // To convert the user uploaded Photo as Byte Array before save to DB
            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];
                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    if (poImgFile.ContentLength != 0)
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
            }
            if (model.UserId == null)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNo, UserPhoto = imageData, DOB = Convert.ToDateTime(model.DOB) };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        //Add Role to this User
                        await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                        // Send an email with this link
                        await ConfirmYourEmail(user.Id);
                        return RedirectToAction("Register", "Account");
                    }
                    ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
                    AddErrors(result);
                }
            }
            else
            {
                // Get the existing User from the db
                var user = UserManager.FindById(model.UserId);
                if (user != null)
                {
                    // Update it with the values from the view model
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.PasswordHash = HashPassword(model.Password);
                    user.PhoneNumber = model.PhoneNo;
                    user.DOB = Convert.ToDateTime(model.DOB);

                    if (imageData != null)
                    {
                        user.UserPhoto = imageData;
                    }
                    else if (user.UserPhoto == null)
                    {
                        user.UserPhoto = imageData;
                    }
                    // Apply the changes if any to the db
                    UserManager.Update(user);
                    //Delete Role and Add to Role
                    var currentRoles = new List<IdentityUserRole>();
                    currentRoles.AddRange(user.Roles);
                    foreach (var role in currentRoles)
                    {
                        var thisRole = context.Roles.Where(r => r.Id.Equals(role.RoleId, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                        UserManager.RemoveFromRole(model.UserId, thisRole.Name);
                    }
                    //Add Role to this User
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    return RedirectToAction("Register", "Account");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            //SMS.SendbyTextLocal("+917905442801", "Hi Sachin This is only a text message by TextLocal.");
            SMS.SendByTwilioWhatsApp("+917905442801", "Hi Sachin, Your email has been confirmed.");
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    ViewBag.Header = "User does not exist!";
                    ViewBag.Error = "It seems that this Email is not registered with us. Please contact to the administrator.";
                    ViewBag.Class = "alert alert-warning";
                    return View("ForgotPasswordConfirmation");
                }
                else if (!(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    ViewBag.Header = "Email does not confirmed!";
                    ViewBag.Error = "It seems that your Email does not confirmed please confirm your Email first or contact to the administrator.";
                    ViewBag.Class = "alert alert-warning";
                    return View("ForgotPasswordConfirmation");

                }
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                StringBuilder st = new StringBuilder();
                st.Append("<!DOCTYPE html><html><head><meta charset='utf - 8'/><title>Reset Password</title></head><body><div style='width: 650px; min - height:420px; margin: 0 auto; padding - top:1px; background - color:#1d8e07'><div style='height:auto;margin-left:8px;width:642px;min-height:420px;background-color:#fff'><div style='min-height:250px;padding:30px 35px 30px;margin:0;line-height:1.5em;word-wrap:break-word'><br /><div>Hi " + user.FirstName + ", <br></div><div><br></div><div>We heard that you lost your password. Sorry about that!<br/>But don’t worry! You can use the following link to reset your password:<br></div><div><br></div>");
                st.Append("<div><a style='border: 1px solid #1d8e07;background:#1d8e07;display:inline-block;padding:7px 15px;text-decoration:none;color:#fff' href=\"" + callbackUrl + "\" target='_blank'>Click here to reset</a> <br></div>");
                st.Append("<div><br></div><br /><br /><br /><div>Thanks!<br></div><div><br></div><div>BASE Institution Team,<br></div></div></div></div></body></html>");

                await UserManager.SendEmailAsync(user.Id, "Reset Password", st.ToString());
                ViewBag.Header = "Email sent succesfully!";
                ViewBag.Error = "Please check your email to reset your password.";
                ViewBag.Class = "alert alert-success";
                return View("ForgotPasswordConfirmation");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }
        public JsonResult SessionTimeout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult ResetSessionTimeout()
        //{
        //    Session.Timeout = Session.Timeout;
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}
        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
        public ActionResult AuthorizationError(string Message)
        {
            ViewBag.ErrorMessage = Message;
            return View();
        }
        // POST: /Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string UserId)
        {
            if (ModelState.IsValid)
            {
                if (UserId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var user = await UserManager.FindByIdAsync(UserId);
                var logins = user.Logins;
                var rolesForUser = await UserManager.GetRolesAsync(UserId);

                using (var transaction = context.Database.BeginTransaction())
                {
                    foreach (var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    await UserManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return RedirectToAction("Register", "Account");
            }
            else
            {
                return View();
            }
        }

        //public Boolean IsAdminUser()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        ApplicationDbContext context = new ApplicationDbContext();
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //        var s = UserManager.GetRoles(user.GetUserId());
        //        if (s[0].ToString() == "Admin")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        // GET: Role
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateRoles()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Admin"))
                {
                    return RedirectToAction("AuthorizationError", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            context = new ApplicationDbContext();
            var Roles = context.Roles.ToList();
            return View(Roles);

        }
        //Post CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoles(CreateRoleModel model)
        {
            context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create Admin Role            
            IdentityResult roleResult;

            // Check to see if Role Exists, if not create it
            if (!RoleManager.RoleExists(model.RoleName))
            {
                roleResult = RoleManager.Create(new IdentityRole(model.RoleName));
            }
            return RedirectToAction("CreateRoles", "Account");
        }

        public ActionResult DeleteRole(string RoleName)
        {
            context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (RoleManager.RoleExists(RoleName))
            {
                var role = RoleManager.FindByName(RoleName);
                RoleManager.Delete(role);
            }
            return RedirectToAction("CreateRoles", "Account");
        }

        public JsonResult GetUser(string UserId)
        {
            try
            {
                if (UserId == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                var user = UserManager.FindById(UserId);
                context = new ApplicationDbContext();
                var UserInfo = new RegisterViewModel();
                if (user != null)
                {
                    UserInfo.UserId = user.Id;
                    UserInfo.FirstName = user.FirstName;
                    UserInfo.LastName = user.LastName;
                    UserInfo.Email = user.Email;
                    UserInfo.PhoneNo = user.PhoneNumber;
                    UserInfo.DOB = Convert.ToString(user.DOB);
                    if (user.UserPhoto != null)
                    {
                        UserInfo.strUserPhoto = "data:image/png;base64," + Convert.ToBase64String(user.UserPhoto);
                    }
                    else
                    {
                        UserInfo.strUserPhoto = "/Images/UserProfileImages/noImgLarge.png";
                    }
                    var Roles = (from userRole in user.Roles
                                 join role in context.Roles on userRole.RoleId equals role.Id
                                 select role.Name).ToList();
                    UserInfo.UserRoles = Roles[0];
                }
                return Json(UserInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #region Menu Management
        // GET: ManageMenu  
        public ActionResult ManageMenu()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Admin"))
                {
                    return RedirectToAction("AuthorizationError", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.MenuCount = context.Menus.Count();
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Menu  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetAllMenu()
        {
            List<Menus> menu = context.Menus.ToList();
            return Json(menu, JsonRequestBehavior.AllowGet);
        }
        /// <summary>  
        /// Insert New Menu  
        /// </summary>  
        /// <param name="menu"></param>  
        /// <returns></returns>  
        public string InsertMenu(Menus menu)
        {
            if (menu != null && ModelState.IsValid)
            {
                context.Menus.Add(menu);
                context.SaveChanges();
                return "Menu Added Successfully";
            }
            else
            {
                return "Menu Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Menu Information  
        /// </summary>  
        /// <param name="menu"></param>  
        /// <returns></returns>  
        public string DeleteMenu(Menus menu)
        {
            if (menu != null)
            {
                var menu_ = context.Entry(menu);
                if (menu_.State == EntityState.Detached)
                {
                    context.Menus.Attach(menu);
                    context.Menus.Remove(menu);
                }
                context.SaveChanges();
                return "Menu Deleted Successfully";
            }
            else
            {
                return "Menu Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Menu Information  
        /// </summary>  
        /// <param name="menu"></param>  
        /// <returns></returns>  
        public string UpdateMenu(Menus menu)
        {
            if (menu != null && ModelState.IsValid)
            {
                var menu_ = context.Entry(menu);
                Menus EmpObj = context.Menus.Where(x => x.MenuId == menu.MenuId).FirstOrDefault();
                EmpObj.MenuName = menu.MenuName;
                EmpObj.MenuIcon = menu.MenuIcon;
                EmpObj.DisplayOrder = menu.DisplayOrder;
                EmpObj.Status = menu.Status;
                context.SaveChanges();
                return "Menu Updated Successfully";
            }
            else
            {
                return "Menu Not Updated! Try Again";
            }
        }
        #endregion

        #region SubMenu Management
        // GET: ManageMenu  
        public ActionResult ManageSubMenu()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Admin"))
                {
                    return RedirectToAction("AuthorizationError", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.SubMenuCount = context.SubMenus.Count();
            return View();
        }
        /// <summary>  
        ///   
        /// Get All SubMenu  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetAllSubMenu()
        {
            var subMenu = (from p in context.SubMenus
                           join pm in context.Menus on p.MenuId equals pm.MenuId
                           select new { p.SubMenuId, p.MenuId, pm.MenuName, p.SubMenuName, p.SubMenuIcon, p.DisplayOrder, p.Status }).ToList();

            return Json(subMenu, JsonRequestBehavior.AllowGet);
        }
        /// <summary>  
        /// Get SubMenu With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult GetSubMenuById(string Id)
        {
            int SubMenuId = int.Parse(Id);
            return Json(context.SubMenus.Find(SubMenuId), JsonRequestBehavior.AllowGet);
        }
        /// <summary>  
        /// Insert New SubMenu  
        /// </summary>  
        /// <param name="subMenu"></param>  
        /// <returns></returns>  
        public string InsertSubMenu(SubMenus subMenu)
        {
            if (subMenu != null && ModelState.IsValid)
            {
                context.SubMenus.Add(subMenu);
                context.SaveChanges();
                return "SubMenu Added Successfully";
            }
            else
            {
                return "SubMenu Not Inserted! Try Again";
            }
        }
        /// <summary>
        /// Delete SubMenu
        /// </summary>
        /// <param name="subMenu"></param>
        /// <returns></returns>
        public string DeleteSubMenu(SubMenus subMenu)
        {
            if (subMenu != null)
            {
                var subMenu_ = context.Entry(subMenu);
                if (subMenu_.State == EntityState.Detached)
                {
                    context.SubMenus.Attach(subMenu);
                    context.SubMenus.Remove(subMenu);
                }
                context.SaveChanges();
                return "SubMenu Deleted Successfully";
            }
            else
            {
                return "SubMenu Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update SubMenu Information  
        /// </summary>  
        /// <param name="subMenu"></param>  
        /// <returns></returns>  
        public string UpdateSubMenu(SubMenus subMenu)
        {
            if (subMenu != null && ModelState.IsValid)
            {
                var menu_ = context.Entry(subMenu);
                SubMenus EmpObj = context.SubMenus.Where(x => x.SubMenuId == subMenu.SubMenuId).FirstOrDefault();
                EmpObj.SubMenuName = subMenu.SubMenuName;
                EmpObj.SubMenuIcon = subMenu.SubMenuIcon;
                EmpObj.MenuId = subMenu.MenuId;
                EmpObj.DisplayOrder = subMenu.DisplayOrder;
                EmpObj.Status = subMenu.Status;
                context.SaveChanges();
                return "SubMenu Updated Successfully";
            }
            else
            {
                return "SubMenu Not Updated! Try Again";
            }
        }
        #endregion

    }
}
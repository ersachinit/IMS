using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using SpiritWorx.BO;
using SpiritWorx.DAL;
using SpiritWorx.Utility;
using System.Xml;

namespace SpiritWorx.BL
{
    public class UserRepository
    {
        #region Add/Update User
        /// <summary>
        /// Add/Update User
        /// </summary>
        /// <returns></returns>
        public static bool AddUpdateUser(User entity)
        {
            var sqlUser = new SqlUser();
            var action = Enums.LoyaltyGatorAction.AddUser;
            if (entity.Id > 0)
            {
                action = Enums.LoyaltyGatorAction.UpdateUser;
            }
            if (entity.SchoolName == null)
            {
                entity.SchoolName = string.Empty;
            }
            if (!string.IsNullOrWhiteSpace(entity.ProfileImage))
            {
                var profileData = entity.ProfileImage.Split(',');
                switch (profileData.Length)
                {
                    case 3:
                        entity.ProfileImageByte = Convert.FromBase64String(profileData[2]);
                        entity.ProfileImage = profileData[0];
                        break;
                }
                if (entity.ProfileImageByte != null && entity.ProfileImageByte.Length > 0)
                {
                    entity.ProfileImage = FileUploadUtility.GetFileName(Path.GetFileNameWithoutExtension(entity.ProfileImage)) + Path.GetExtension(entity.ProfileImage);
                    entity.ProfileImage = FileUploadUtility.ConvertByteToImage(entity.ProfileImageByte, entity.ProfileImage, WebConstant.ConfigKey.UserProfilePhysicalFilePath) ? entity.ProfileImage : "";
                    if (!string.IsNullOrWhiteSpace(entity.ProfileImage))
                    {
                        string profileImageIcon = Utilities.ResizeImage(entity.ProfileImage, 100, 100, WebConstant.ConfigKey.UserProfilePhysicalFilePath);
                        entity.ProfileImage = !string.IsNullOrWhiteSpace(profileImageIcon) ? profileImageIcon : entity.ProfileImage;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(entity.TaxExemptFile))
            {
                var taxExemptData = entity.TaxExemptFile.Split(',');
                byte[] taxExemptDataByte = { };
                switch (taxExemptData.Length)
                {
                    case 3:
                        taxExemptDataByte = Convert.FromBase64String(taxExemptData[2]);
                        entity.ProfileImage = taxExemptData[0];
                        break;
                }
                if (taxExemptDataByte.Length > 0)
                {
                    var fileExtension = Path.GetExtension(entity.TaxExemptFile);
                    var fileType = fileExtension.FileType();
                    entity.TaxExemptFile = FileUploadUtility.GetFileName(Path.GetFileNameWithoutExtension(entity.TaxExemptFile)) + fileExtension;
                    switch (fileType)
                    {
                        case "IMAGE":
                            entity.TaxExemptFile = FileUploadUtility.ConvertByteToImage(taxExemptDataByte, entity.TaxExemptFile, WebConstant.ConfigKey.OrdersFilePath) ? entity.TaxExemptFile : "";
                            break;
                        case "PDF":
                        case "DOC":
                            entity.TaxExemptFile = FileUploadUtility.ConvertByteToDoc(taxExemptDataByte, entity.TaxExemptFile, WebConstant.ConfigKey.OrdersFilePath) ? entity.TaxExemptFile : "";
                            break;
                    }
                }
            }

            bool isAddUpdated = sqlUser.AddUpdateUser(entity);
            if (isAddUpdated)
            {
                if (Utilities.EnableLoyaltyGator)
                {
                    LoyaltyGatorRepository.AddUpdateLoyaltyGatorUser(entity, action);
                }
            }
            return isAddUpdated;
        }
        #endregion

        #region Gets the user
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The Password</param>
        /// <param name="status">The is active.</param>
        /// <returns></returns>
        public static User FindUser(int? userId = null, string emailAddress = null, string password = null, Enums.Status status = Enums.Status.NotDefined)
        {
            var sqlUser = new SqlUser();
            return sqlUser.GetUser(userId, emailAddress, password, status);
        }
        #endregion


        #region Gets the user
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The Password</param>
        /// <param name="status">The is active.</param>
        /// <returns></returns>
        public static User FindUserProfile(int? userId = null, string emailAddress = null, string password = null, Enums.Status status = Enums.Status.NotDefined)
        {
            var sqlUser = new SqlUser();
            return sqlUser.GetUserProfile(userId, emailAddress, password, status);
        }
        #endregion

        #region Change Password
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static ResponseOutput ChangePassword(string currentPassword, string newPassword)
        {
            var responseOutput = new ResponseOutput();
            responseOutput.IsSuccessful = false;
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                responseOutput.OutputMessage = "New password is empty.";
                return responseOutput;
            }
            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                responseOutput.OutputMessage = "Current password is empty.";
                return responseOutput;
            }
            if (UserContext.Current.User.IsAnonymous == true)
            {
                responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                responseOutput.OutputMessage = "User is not logged in.";
                return responseOutput;
            }
            if (!string.IsNullOrWhiteSpace(currentPassword) && !string.IsNullOrWhiteSpace(newPassword) && UserContext.Current.User.IsAnonymous == false)
            {
                SqlUser sqlUser = new SqlUser();
                var userid = UserContext.Current.User.Id;
                var user = FindUser(userid);
                if (user != null)
                {
                    if (user.Password == currentPassword)
                    {
                        bool isChanged = sqlUser.ChangePassword(userid, currentPassword, newPassword);
                        responseOutput.IsSuccessful = isChanged;
                        if (!isChanged)
                        {
                            responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                            responseOutput.OutputMessage = "Password has been not changed.";
                        }
                        else
                        {
                            responseOutput.TypeOfException = Enums.ExceptionType.NoException;
                            responseOutput.OutputMessage = "Your password has been successfully changed.";
                        }
                    }
                    else
                    {
                        responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                        responseOutput.OutputMessage = "Current Password is not matched.";
                    }
                }
                else
                {
                    responseOutput.TypeOfException = Enums.ExceptionType.Fault;
                    responseOutput.OutputMessage = "User is not exist.";
                }
            }
            return responseOutput;
        }
        #endregion

        #region Logins the Specified Username
        /// <summary>
        /// Logins the Specified Username.
        /// </summary>
        /// <param name="emailAddress">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns></returns>
        public static User Login(string emailAddress, string password, bool rememberMe = false)
        {
            Enums.UserLoginStatus userLoginStatus = Enums.UserLoginStatus.InvalidCredentials;
            User user = new User();
            if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
            {
                user.UserLoginStatus = Enums.UserLoginStatus.EmptyUserNameOrPassword;
                return user;
            }
            else
            {
                if (GetLocationCountryCode(emailAddress))
                {
                    //Load user details
                    user = FindUser(emailAddress: emailAddress, password: password, status: Enums.Status.Active);
                    if (user != null)
                    {
                        if (user.Password == password)
                        {
                            switch (user.Status)
                            {
                                case Enums.Status.Pending:
                                    userLoginStatus = Enums.UserLoginStatus.AccountPending;
                                    break;
                                case Enums.Status.Banned:
                                    userLoginStatus = Enums.UserLoginStatus.AccountBanned;
                                    break;
                                case Enums.Status.Disapproved:
                                    userLoginStatus = Enums.UserLoginStatus.AccountDisapproved;
                                    break;
                                case Enums.Status.Active:
                                    userLoginStatus = Enums.UserLoginStatus.Success;
                                    break;
                            }
                        }
                        else
                        {
                            user.UserLoginStatus = Enums.UserLoginStatus.InvalidCredentials;
                            return user;
                        }

                    }
                    else
                    {
                        user = new User { UserLoginStatus = Enums.UserLoginStatus.InvalidCredentials };
                        return user;
                    }

                }
                else
                {
                    user.UserLoginStatus = Enums.UserLoginStatus.InvalidCredentials;
                    return user;
                }
            }

            if (userLoginStatus == Enums.UserLoginStatus.Success)
            {
                /*
                 * Create a persistemt cookie if Remember Me is checked (10 days approx)
                 * Note: time in min. should be same as cookie expiration
                 * The forms authentication feature only looks at the expiration time set on the forms authentication ticket. It never looks at the expiration date set on the cookie itself.  
                 * The reason is that the forms authentication ticket is encrypted and digitally signed, so its payload can be trusted.  However a malicious user can easily forge an Http 
                 * cookie with a fake expiration date.  The only purpose of the cookie's expiration date in forms authentication is that by explicitly setting an expiry date, the cookie 
                 * will be persisted in the user's browser cache.  This how "remember me" functionality works - the forms auth ticket is packaged into a cookie and the cookie has an explicit
                 * expiration date.  That way when a user returns to the site at some future point in time, the browser just automatically sends the forms auth cookie back to the server.  
                 * However the server decrypts the payload of the cookie, and then looks at the expiration date contained in the payload (not the expiry date of the cookie itself) to determine 
                 * if the forms auth ticket should still be considered valid.
                 * Unless the intent is to make the cookie stick around on a user's machine, you don't need to set the Expiration property of the HttpCookie.  If you do want a persistent cookie, 
                 * then when you manually issue it you need to ensure that the expiration date in the forms auth ticket and the expiry on the coookie itself are using the same duration.  
                 * Otherwise you can end up in a weird situation where the date in the forms auth ticket and the date on the cookie don't match.
                 */

                var ticket = new FormsAuthenticationTicket(1, emailAddress, DateTime.Now, DateTime.Now.AddDays(2), rememberMe, password);
                string ticketString = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketString);

                if (rememberMe)
                {
                    cookie.Expires = DateTime.Now.AddDays(10);
                }
                UserContext.Current.Context.Response.Cookies.Add(cookie);
                if (UserContext.Current.Context.Session != null)
                {
                    UserContext.Current.User = user;
                }
            }
            user.UserLoginStatus = userLoginStatus;
            return user;
        }
        #endregion

        #region Gets the user
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="startPage">The start page.</param>
        /// <param name="pageLength">Length of the page.</param>
        /// <param name="noOfPages">The no of pages.</param>
        /// <param name="totalRecords">The total records.</param>
        /// <returns></returns>
        public static IList<User> FindUsers(int startPage, int pageLength, out int noOfPages, out int totalRecords)
        {
            return FindUsers(null, startPage, pageLength, out noOfPages, out totalRecords);
        }
        public static IList<User> FindUsers(string email, int startPage, int pageLength, out int noOfPages, out int totalRecords)
        {
            return FindUsers(email, null, startPage, pageLength, out noOfPages, out totalRecords);
        }

        public static IList<User> FindUsers(string email, string name, int startPage, int pageLength, out int noOfPages, out int totalRecords)
        {
            SqlUser sqlUser = new SqlUser();
            return sqlUser.GetUsers(email, name, startPage, pageLength, out noOfPages, out totalRecords);
        }
        #endregion

        #region Deletes the user
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="dtUserId">The dt user id.</param>
        /// <returns></returns>
        public static bool DeleteUser(DataTable dtUserId)
        {
            if (dtUserId.Rows.Count > 0)
            {
                SqlUser sqlUser = new SqlUser();
                return sqlUser.DeleteUser(dtUserId);
            }
            return false;

        }
        #endregion

        #region Check Availability Of User Email

        /// <summary>
        /// Checks if the User Email is available for registration.
        /// </summary>
        /// <param name="email">User Email to be checked</param>
        /// <param name="userId"></param>
        /// <returns>
        /// Returns true if User Email is available, else false.
        /// </returns>
        public static ResponseOutput CheckUserEmailAvailability(string email, int userId = 0)
        {
            SqlUser sqlUser = new SqlUser();
            ResponseOutput responseOutput = new ResponseOutput();
            responseOutput.IsSuccessful = false;
            if (!string.IsNullOrWhiteSpace(email))
            {
                bool ret = sqlUser.CheckUserEmailAvailability(email, userId);
                if (ret)
                {
                    responseOutput.IsSuccessful = true;
                    responseOutput.OutputMessage = string.Empty;
                }
                else
                {
                    responseOutput.IsSuccessful = false;
                    responseOutput.OutputMessage = "Entered email Id already used, please use another email Id.";
                }
            }
            else
            {
                responseOutput.IsSuccessful = false;
                responseOutput.OutputMessage = "Please enter email Id.";
            }
            return responseOutput;
        }
        #endregion


        #region Delete User Profile Image
        /// <summary>
        /// Delete User Profile Image
        /// </summary>
        /// <returns></returns>
        public static bool DeleteProfileImage(int userId)
        {
            var sqlUser = new SqlUser();
            return sqlUser.DeleteProfileImage(userId);
        }
        #endregion

        public static bool GetLocationCountryCode(string emailAddress)
        {
            string emailAddresses = "admin@spiritworx.com,kayla@spiritworx.com";
            bool blFlag = true;
            if (emailAddresses.Contains(emailAddress))
            {
                string countryCode = "";
                string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                XmlDocument doc = new XmlDocument();
                //string getdetails = "http://www.freegeoip.net/xml/" + ip;
                string getdetails = "http://api.ipstack.com/"+ ip + "?access_key="+ Utilities.IP_Access_key + "&output=xml";
                doc.Load(getdetails);
                XmlNodeList nodeLstCity = doc.GetElementsByTagName("country_code");
                if (nodeLstCity.Count > 0)
                    countryCode = nodeLstCity[0].InnerText;
                if (!string.IsNullOrEmpty(countryCode))
                {
                    if (countryCode != "US")
                        blFlag = false;
                }
            }
            return blFlag;
        }

        public static List<UserOrderDiscount> GetOrderDiscounts(int userId)
        {
            SqlUser sqlUser = new SqlUser();
            return sqlUser.GetOrderDiscounts(userId);
        }

        public static User UserInstance()
        {
            return new User { IsProfile = true };
        }

        public static int CheckUserSession()
        {
            int userId = UserContext.Current.User.Id;
            return userId;
        }

    }//end class
}//end namespace
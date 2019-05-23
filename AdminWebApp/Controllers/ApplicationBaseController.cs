using AdminWebApp.Models;
using BusinessAccessLayer;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{
    public class ApplicationBaseController : Controller
    {
        CommonBAL bal = new CommonBAL();
        protected void SetUserImage(byte[] userPhoto)
        {
            if (Session["UserPhoto"] == null)
            {
                if (userPhoto != null)
                {
                    Session["UserPhoto"] = "data:image/png;base64," + Convert.ToBase64String(userPhoto);
                }
                else
                {
                    Session["UserPhoto"] = "/Images/UserProfileImages/noImgSmall.png";
                }
            }            
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = string.Concat(new string[] { user.FirstName, " ", user.LastName });
                    ViewData.Add("FullName", fullName);
                    ViewData.Add("FirstName", user.FirstName);
                    ViewData.Add("SessionTimeout", Session.Timeout);
                    SetUserImage(user.UserPhoto);
                    if (Session["MenuList"] == null)
                    {
                        var Roles = (from userRole in user.Roles
                                     join role in context.Roles on userRole.RoleId equals role.Id
                                     select role.Id).ToList();
                        Session["MenuList"] = bal.GetMenuByRole(Roles[0]);
                        ViewBag.MenuByRole = Session["MenuList"];
                    }
                    else
                    {
                        ViewBag.MenuByRole = Session["MenuList"];
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}
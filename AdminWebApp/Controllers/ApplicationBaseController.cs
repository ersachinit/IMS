using AdminWebApp.Models;
using BusinessAccessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{
    public class ApplicationBaseController : Controller
    {
        CommonDataAccess bal = new CommonDataAccess();
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
                    if (Session["MenuList"] == null)
                    {
                        var Roles = (from userRole in user.Roles
                                     join role in context.Roles on userRole.RoleId equals role.Id
                                     select role.Id).ToList();

                        ArrayList FieldName = new ArrayList();
                        FieldName.Add("RoleId");

                        ArrayList FieldValue = new ArrayList();
                        FieldValue.Add(Roles[0]);

                        ArrayList FieldType = new ArrayList();
                        FieldType.Add("NVarchar");
                        Session["MenuList"] = bal.GetMenuList("GetMenuByRole", FieldName, FieldType, FieldValue);
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
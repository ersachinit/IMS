using AdminWebApp.Models;
using BusinessDataModel;
using BusinessAccessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(AdminWebApp.Startup))]
namespace AdminWebApp
{
    public partial class Startup
    {
        CommonBAL bal = new CommonBAL();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
        //In this method we will create default User roles and Admin user for login
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("SuperAdmin"))
            {

                // first we create SuperAdmin role   
                var role = new IdentityRole("SuperAdmin");

                //Here we create a SuperAdmin user who will maintain the website  
                var user = new ApplicationUser
                {
                    UserName = ConfigurationManager.AppSettings["AdminEmail"],
                    Email = ConfigurationManager.AppSettings["AdminEmail"],
                    FirstName = ConfigurationManager.AppSettings["FirstName"],
                    LastName = ConfigurationManager.AppSettings["LastName"],
                    PhoneNumber = ConfigurationManager.AppSettings["Phone"],
                    EmailConfirmed = true,
                    Active = true,
                    CompanyId = "0",
                    DOB = DateTime.Now,
                };
                string userPWD = ConfigurationManager.AppSettings["AdminPassword"];
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    //Create Role
                    roleManager.Create(role);

                    //Update Created by
                    var superUser = UserManager.FindByName(ConfigurationManager.AppSettings["AdminEmail"]);
                    superUser.CreatedBy = superUser.Id;
                    UserManager.Update(user);

                    //Assign Role To USer
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

                    //Assign all Menus
                    AssignMenus(role.Id);
                }
            }
            // creating Creating Manager role     
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }
            // creating Creating Employee role     
            if (!roleManager.RoleExists("Account"))
            {
                var role = new IdentityRole("Account");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Faculty"))
            {
                var role = new IdentityRole("Faculty");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Trial"))
            {
                var role = new IdentityRole("Trial");
                roleManager.Create(role);
            }
        }

        /// <summary>
        /// Assign All Menus to SuperAdmin
        /// </summary>
        /// <param name="roleId"></param>
        private void AssignMenus(string roleId)
        {
            List<BDMMenus> menuList = new List<BDMMenus>();
            List<string> menuIds = new List<string>();

            menuList = bal.GetMenuByRole("");
            foreach (var item in menuList)
            {
                menuIds.Add(Convert.ToString(item.MenuId));
            }
            ApplicationDbContext context = new ApplicationDbContext();
            RoleMenus model = new RoleMenus();
            model.MenuIds = string.Join(",", menuIds.ToArray());
            model.RoleId = roleId;
            if (model.Id == 0)
            {
                context.RoleMenus.Add(model);
                context.SaveChanges();
            }
        }
    }
}

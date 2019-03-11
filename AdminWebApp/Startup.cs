using AdminWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(AdminWebApp.Startup))]
namespace AdminWebApp
{
    public partial class Startup
    {
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
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser
                {
                    UserName = ConfigurationManager.AppSettings["Email"],
                    Email = ConfigurationManager.AppSettings["Email"],
                    //FirstName = "Sachin",
                    //LastName = "Tripathi",
                    //PhoneNumber = "7905442801",
                    EmailConfirmed = true,
                    //DOB = Convert.ToDateTime("07/06/1992")
                };
                string userPWD = ConfigurationManager.AppSettings["Password"];
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole("Manager");
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole("Employee");
                roleManager.Create(role);

            }
        }
    }
}

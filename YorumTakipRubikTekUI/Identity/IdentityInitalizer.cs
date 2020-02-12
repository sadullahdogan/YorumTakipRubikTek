using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YorumTakipRubikTekUI.Identity
{
    public class IdentityInitalizer:CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Roller
            if (!context.Roles.Any(x => x.Name == "admin")) {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Decsription = "Admin Role" };
                manager.Create(role);
                
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Decsription = "User Role" };
                manager.Create(role);

            }
            

            //user

            if (!context.Users.Any(x => x.Name == "admin"))
            {
                var store = new UserStore<ApplicationUsers>(context);
                var manager = new UserManager<ApplicationUsers>(store);
                var user = new ApplicationUsers() { Name = "user",Surname="user",UserName="user.user"};
                manager.Create(user, "userpwd");
                
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}
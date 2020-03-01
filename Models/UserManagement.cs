using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiEFTest.Models
{
    public class UserManagement : IUserManagement
    {
        readonly UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        public void ChangeBalance(ApplicationUser user, int powwwers) {
            user.Powwwers += powwwers;
            UserManager.Update(user);
        }

        public ApplicationUser Find(string userName) {
            return UserManager.FindByEmail(userName);
        }
    }
}
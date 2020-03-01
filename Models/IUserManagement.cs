using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEFTest.Models
{
    public interface IUserManagement
    {
        // TODO: убрать applicationuser
        ApplicationUser Find(string userName);
        void ChangeBalance(ApplicationUser user, int powwwers);
    }
}

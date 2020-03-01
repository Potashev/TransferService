using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiEFTest.Models;

namespace WebApiEFTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Register() {
            return View();
        }

        [Authorize]
        public ActionResult UserPage() {
            return View();
        }
    }
}

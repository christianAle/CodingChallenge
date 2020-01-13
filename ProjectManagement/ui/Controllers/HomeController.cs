using Kendo.Mvc.UI;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public static UserService UserService = new UserService();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult User()
        {

            return View();
        }

        public ActionResult Project()
        {

            return View();
        }
    }   
}

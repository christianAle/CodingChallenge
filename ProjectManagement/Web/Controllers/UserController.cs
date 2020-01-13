using Kendo.Mvc.UI;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public static UserService UserService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User(Models.User data) 
        {
            try
            {
                Repository.User userData = new Repository.User();
                userData.FirstName = data.FirstName;
                userData.LastName = data.LastName;
                UserService.CreateUser(userData);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }
            return View();
        }

        public ActionResult GetUsers([DataSourceRequest] DataSource request)
        {
            try
            {
                var result = UserService.getAll();
                if (result != null) {
                    return this.Json(result);
                }
                else
                {
                    return this.Json("");
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }
        }

    }
}
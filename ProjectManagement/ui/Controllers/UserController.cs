using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public static UserService UserService = new UserService();

        [HttpPost]
        public ActionResult User(Models.User data)
        {
            try
            {
                Repository.User userData = new Repository.User();
                userData.FirstName = data.FirstName;
                userData.LastName = data.LastName;
                UserService.Create(userData);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            try
            {   
                var result = UserService.Retrive();
                var UserList = new List<Models.User>();
                if (result != null)
                {
                    UserList = result.Select(x => new Models.User()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName

                    }).ToList();
                    return this.Json(UserList.ToDataSourceResult(request));
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

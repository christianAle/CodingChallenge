using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class UserProjectController : Controller
    {
        // GET: UserProject
        public static UserProjectService UserProjectService = new UserProjectService();
        public static UserService UserService = new UserService();
        public static ProjectService ProjectService = new ProjectService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserProject(Models.UserProject data)
        {
            try
            {
                Repository.UserProject userProjectData = new Repository.UserProject()
                    {
                   UserId = data.UserId,
                    ProjectId = data.ProjectId,
                    IsActive = data.isActive,
                    AssignedDate = data.AssignedDate
                   };


                UserProjectService.Create(userProjectData);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.InnerException });
            }
            return View();
        }

        public ActionResult GetUserProjects([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = UserProjectService.Retrive();
                var userProjects = new List<Models.UserProject>();
                if (result != null)
                {
                    userProjects = result.Select(x => new Models.UserProject()
                    {
                        User = x.User,
                        Project = x.Project,
                        isActive = x.IsActive,
                        AssignedDate = x.AssignedDate

                    }).ToList();
                    return this.Json(userProjects.ToDataSourceResult(request));
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

        //public T convertObject<T>( T entityToConvert, T Dynamic ) 
        //{
        //    var serializeObject = JsonConvert.SerializeObject(entityToConvert);
        //    var DeserializeObject = JsonConvert.DeserializeObject(serializeObject, typeof(targetObject));
        //    T = DeserializeObject;

        //    return  T;
        //}

         [HttpPost]
        public JsonResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = UserService.getAll();
                var UserList = new List<Models.User>();
                if (result != null)
                {
                    UserList = result.Select(x => new Models.User()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName

                    }).ToList();
                    return this.Json(UserList);
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

        [HttpPost]

        public JsonResult GetProjects([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = ProjectService.Retrive();
                var projectList = new List<Models.Project>();
                if (result != null)
                {
                    projectList = result.Select(x => new Models.Project()
                    {
                        Id = x.Id,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Credits = x.Credits

                    }).ToList();
                    return this.Json(projectList);
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
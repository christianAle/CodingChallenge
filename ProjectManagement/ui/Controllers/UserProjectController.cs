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

        [HttpPost]
        public ActionResult GetUserProjects(int id)
        {
            try
            {
                var result = UserProjectService.Retrive();
                var userProjects = new List<Models.UserProject>();
                var projects =   ProjectService.Retrive();
                var resultProject = new List<Models.Project>();

                if (result != null && projects != null)
                {
                    foreach (var us in userProjects) {
                        foreach (var p in projects) {
                            if (us.UserId == id  && p.Id == us.ProjectId)
                            {
                                resultProject.Add(new Models.Project() {
                                    Id = p.Id,
                                    StartDate = p.StartDate,
                                    EndDate = p.EndDate,
                                    Credits = p.Credits
                                });
                            }
                        } 
                    }
                    return this.Json(resultProject);
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
        public JsonResult GetUsers([DataSourceRequest] DataSourceRequest request)
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
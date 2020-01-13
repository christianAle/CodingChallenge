using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public static  ProjectService ProjectService = new ProjectService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Project(Models.Project data)
        {
            try
            {
                Repository.Project projectData = new Repository.Project();
                projectData.StartDate = data.StartDate;
                projectData.EndDate = data.EndDate;
                projectData.Credits = data.Credits;
                ProjectService.Create(projectData);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.InnerException });
            }
            return View();
        }



        public ActionResult GetProjects([DataSourceRequest] DataSourceRequest request)
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
                    return this.Json(projectList.ToDataSourceResult(request));
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
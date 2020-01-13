using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjectService : IRepository<Project>
    {

        public void Create(Project entity)
        {
            try {
                using (var db = new CodeChallengeEntities())
                {
                    db.Projects.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex) {
               var messgae=  ex.Message;
            }
           
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Project FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }

        public List<Project> Retrive()
        {
            var projectList = new List<Project>();

            using (var db = new CodeChallengeEntities())
            {
                var query = from p in db.Projects
                            select p;
                foreach (var item in query)
                {
                    projectList.Add(item);
                }
            }
            return projectList;
        }
    }
}

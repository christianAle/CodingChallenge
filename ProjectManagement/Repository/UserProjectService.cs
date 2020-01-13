using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserProjectService : IRepository<UserProject>
    {
        public void Create(UserProject entity)
        {
            using (var db = new CodeChallengeEntities())
            {
                SqlParameter UserId = new SqlParameter("@UserId", entity.UserId);
                SqlParameter ProjectId = new SqlParameter("@ProjectId", entity.ProjectId);
                SqlParameter IsActive = new SqlParameter("@IsActive", entity.IsActive);
                SqlParameter AssignedDate = new SqlParameter("@AssignedDate", entity.AssignedDate);

                db.Database.ExecuteSqlCommand("addUserProject @UserId, @ProjectId, @IsActive, @AssignedDate", UserId, ProjectId, IsActive,AssignedDate);
                db.SaveChanges();
            }
        }

        public List<UserProject> Retrive()
        {
            var userProjectList = new List<UserProject>();

            using (var db = new CodeChallengeEntities())
            {
                var query = from U in db.UserProjects
                            select U;
                foreach (var item in query)
                {
                    userProjectList.Add(item);
                }
            }
            return userProjectList;
        }

    }
}

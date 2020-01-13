﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class UserService
    {
        public void  CreateUser(User user) {
           
            using (var db = new CodeChallengeEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public List<User> getAll() {
            var userList = new List<User>();

            using (var db = new CodeChallengeEntities())
            {
                var query = from U in db.Users
                            select U;
                foreach (var item in query) {
                    userList.Add(item);
                }
            }
            return userList;
        }
    }
}

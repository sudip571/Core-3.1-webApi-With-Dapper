using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace FD.DAL.Repository.User
{
   public class UserRepository : IUserRepository
    {

        public Entities.User GetUserByEmail(string email)
        {
            // query against db and get data
            if(email == "admin@test.com")
            {
                return new Entities.User()
                {
                    Email = "admin@test.com",
                    Id = 1,
                    UserName = "admin"
                };
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FD.DAL.Repository.User
{
   public  interface IUserRepository
    {
        Entities.User GetUserByEmail(string email);
    }
}

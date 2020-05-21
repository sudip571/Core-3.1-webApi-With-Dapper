using FD.BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Services.User
{
   public  interface IUserService
    {
        UserModel GetUser(UserLogIn user);
    }
}

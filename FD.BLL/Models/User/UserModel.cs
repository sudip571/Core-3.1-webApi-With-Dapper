using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        // public string PasswordSalt { get; set; }

        //public Role Role { get; set; }
    }
}

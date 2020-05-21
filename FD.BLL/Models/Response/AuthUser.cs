using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Models.Response
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

using System;

namespace AuthJWT.WebAPI.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public bool IsAuthenticaded { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}

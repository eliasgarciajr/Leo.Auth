using AuthJWT.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace AuthJWT.WebAPI.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Username = "leo", Password = "Madeiras@14072021" });

            return 
                users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}

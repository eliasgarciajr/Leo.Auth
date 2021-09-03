using Leo.Auth.Models;
using System.Collections.Generic;
using System.Linq;

namespace Leo.Auth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User { Username = "elias", 
                                 Password = "elias@123" });

            return 
                users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}

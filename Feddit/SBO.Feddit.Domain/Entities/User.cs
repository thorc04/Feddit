using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class User
    {
        public int? UserID { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ProfilePicture { get; set; }

        public User(int? userId, string username, string password, string email, DateTime registrationDate, string profilePicture)
        {
            UserID = userId;
            Username = username;
            Password = password;
            Email = email;
            RegistrationDate = registrationDate;
            ProfilePicture = profilePicture;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeratingProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int OrderNumber { get; set; }
        public string Password { get; set; }
        public bool Ban { get; set; }
        //public string UsernameSearch { get; set; }

        public UserModel(int id, string username = "<?>", string password = "<?>", bool ban = false)
        {
            Id = id;
            Username = username;
            Password = password;
            Ban = ban;
        }

        public static UserModel GetClone(UserModel user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return new UserModel(user.Id)
            {
                Username = user.Username,
                Password = user.Password,
                Ban = user.Ban,
            };
        }
        /*public override string ToString()
        {
            return $"{Id}: {Username} {Password}";
        }*/
    }

}

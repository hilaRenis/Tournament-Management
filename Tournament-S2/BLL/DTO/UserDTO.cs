using BLL.Enum;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the password.")]
        public string Password { get; set; }

        public Role Role { get; set; }

        public UserDTO() { }

        public UserDTO (Users users)
        {
            Id = users.Id;
            Name = users.Name;  
            LastName = users.LastName;
            Username = users.Username;
            Password = users.Password;
            Role = users.Role;
        }
    }
}

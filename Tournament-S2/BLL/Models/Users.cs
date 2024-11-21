using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BLL.Enum;
using System.Xml.Linq;

namespace BLL.Models
{
    public class Users : Account
    { 
        public Users() { }

        public Users(int id) 
        {
            Id = id;
        }

        public Users(int id, string role)
        {
            Id = id;
            Role = (Role)System.Enum.Parse(typeof(Role), role);
        }

        public Users(string username) : base(username)
        {
        }


        public Users(string username, string password, string salt) : base(username, password, salt)
        {
             
        }
        public Users( string name, string lastName, string username, string password, string salt) : base(username, password, salt)
        {
            Name = name;
            LastName = lastName;
        }

        public Users(int id,string username, string password, string salt) : base(username, password, salt)
        {
            Id = id;
        }

        public Users(int id, string name, string lastName, string username, string password, string salt) : base(username, password, salt)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
        public Users(int id,string name, string lastName, string username, string password, Role role, string salt) : base(username, password, salt)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Role = role;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using BLL.Utils;

namespace BLL.Models
{
    public class Account
    {
        public Account()
        {
        }

        public Account(string username)
        {
            SetUsername(username);
        }

        public Account(string username, string password, string salt)
        {
            SetUsername(username);
            SetSalt(salt);
            SetPassword(password);
        }

        [Required]
        public string Username { get; private set; }

        [Required]
        public string Password
        { get; private set; }

        [Required]
        public string Salt 
        { get; private set; }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty.");
            }

            Username = username;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            Password = password;
        }

        public void SetSalt(string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException("Salt cannot be null or empty.");
            }

            Salt = salt;
        }
    }
}

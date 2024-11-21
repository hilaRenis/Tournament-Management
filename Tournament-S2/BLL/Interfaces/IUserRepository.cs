using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUserRepository
    {
        public bool CreateUser(Users user);
        public Users GetUser(string username, string password);
        public Users GetUserByUsername(string username);
        public List<Users> GetUsers();
        public int CountUserByUserName(string userName);
        public Users GetUserById(int userId);
        public bool UpdateUser(Users user);
        public bool DeleteUser(int userId);
    }
}

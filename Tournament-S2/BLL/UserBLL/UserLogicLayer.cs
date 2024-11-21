using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserBLL
{
    public class UserLogicLayer
    {
        private readonly IUserRepository userRepository;

        public UserLogicLayer(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> userList = new List<Users>();
            userList = userRepository.GetUsers();
            return userList;
        }

        public Users GetUser(Users user)
        {
            return userRepository.GetUser(user.Username, user.Password);
        }

        public Users GetUserByUsername(Users user)
        {
            return userRepository.GetUserByUsername(user.Username);
        }

        public Users GetUserById(Users user)
        {
            return userRepository.GetUserById(user.Id);
        }

        public bool CreateUser(Users user)
        {
            int count = userRepository.CountUserByUserName(user.Username);

            if (count == 0)
            {
                return userRepository.CreateUser(user);
            }

            return false;
        }

        public bool UpdateUser(Users user)
        {
            return userRepository.UpdateUser(user);
        }

        public bool DeleteUser(Users user)
        {
            return userRepository.DeleteUser(user.Id);
        }
    }
}

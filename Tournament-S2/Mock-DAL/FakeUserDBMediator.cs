using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Mock_DAL
{
    public class FakeUserDBMediator : IUserRepository
    {
        private List<Users> users;

        public FakeUserDBMediator()
        {
            this.users = new List<Users>();
        }

        public int CountUserByUserName(string userName)
        {
            int count = 0;
            foreach (Users user in this.users)
            {
                if (user.Username == userName)
                    count++;
            }

            return count;
        }

        public bool CreateUser(Users user)
        {
            if (user == null)
            {
                return false;
            }

            this.users.Add(user);
            return true;
        }

        public bool DeleteUser(int userId)
        {
            if (GetUserById(userId) != null)
            {
                return this.users.Remove(GetUserById(userId));
            }

            return false;
        }

        public Users GetUser(string username, string password)
        {
            foreach (Users user in this.users)
            {
                if (user.Username == username && user.Password == password)
                    return user;
            }

            return null;
        }

        public Users GetUserById(int userId)
        {
            foreach (Users user in this.users)
            {
                if (user.Id == userId)
                    return user;
            }

            return null;
        }

        public Users GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            return this.users;
        }

        public bool UpdateUser(Users newUser)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == newUser.Id)
                {
                    users[i] = newUser;
                    return true;
                }
            }

            return false;
        }
    }
}

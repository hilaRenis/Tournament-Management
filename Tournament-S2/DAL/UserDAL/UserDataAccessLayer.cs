using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BLL.Enum;
using BLL.Models;
using BLL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAL.UserDAL
{
    public class UserDataAccessLayer : IUserRepository
    {
        private readonly IConfiguration configuration;
        public UserDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool CreateUser(Users user)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "INSERT INTO [User] (Name, LastName, Username, Password, Salt, Role) " +
                                  "VALUES (@Name, @LastName, @Username, @Password, @Salt, @Role)";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);
                cmd.Parameters.AddWithValue("@Role", Role.USER.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
        }

        public Users GetUser(string username, string password)
        {
            Users userLogIn = null;

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [User] WHERE Username = @username and Password = @password";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string name = rdr["Name"].ToString();
                    string lastName = rdr["LastName"].ToString();
                    string salt = rdr["Salt"].ToString();
                    Role role = (Role)System.Enum.Parse(typeof(Role), rdr["Role"].ToString());

                    userLogIn = new Users(id, name, lastName, username, password, salt)
                    {
                        Role = role
                    };
                }
            }

            return userLogIn;
        }

        public Users GetUserByUsername(string username)
        {
            Users userLogIn = null;

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [User] WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@username", username);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string name = rdr["Name"].ToString();
                    string lastName = rdr["LastName"].ToString();
                    string salt = rdr["Salt"].ToString();
                    string password = rdr["Password"].ToString();
                    Role role = (Role)System.Enum.Parse(typeof(Role), rdr["Role"].ToString());

                    userLogIn = new Users(id, name, lastName, username, password,salt)
                    {
                        Role = role
                    };
                }
            }

            return userLogIn;
        }

        public List<Users> GetUsers()
        {
            List<Users> userList = new List<Users>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = " SELECT * FROM [User] where Role = 'USER'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Users user = new Users(rdr["Username"].ToString(), rdr["Password"].ToString(), rdr["Salt"].ToString());
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.Name = rdr["Name"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Role = (Role)System.Enum.Parse(typeof(Role), rdr["Role"].ToString());

                    userList.Add(user);
                }
            }

            return userList;
        }

        public int CountUserByUserName(string userName)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT count(*) FROM [User] Where Username = @userName";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@userName", userName);

                con.Open();
                int count = (Int32)cmd.ExecuteScalar();

                return count;
            }
        }

        public Users GetUserById(int userId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [User] WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", userId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Users user = null;

                if (rdr.Read())
                {
                    string username = rdr["Username"].ToString();
                    string password = rdr["Password"].ToString();
                    string salt = rdr["Salt"].ToString();

                    user = new Users(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["LastName"].ToString(), username, password, salt)
                    {
                        Role = (Role)System.Enum.Parse(typeof(Role), rdr["Role"].ToString())
                    };
                }

                return user;
            }
        }

        public bool UpdateUser(Users user)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "UPDATE [User] SET Name = @name, LastName = @lastName," +
                    "Username = @username, Password = @password, Salt=@Salt, Role = @role Where Id = @id";

                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@salt", user.Salt);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", user.Role.ToString());
                command.Parameters.AddWithValue("@id", user.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                string sqlQuery = " Delete From [User] where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Id", userId);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
        }
    }
}

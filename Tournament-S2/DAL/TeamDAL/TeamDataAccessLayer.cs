using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.Enum;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DAL.TeamDAL
{
    public class TeamDataAccessLayer : ITeamRepository
    {
        private readonly IConfiguration configuration;
        public TeamDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Team> GetTeams()
        {
            List<Team> TeamList = new List<Team>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = " SELECT * FROM [Team]";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string name = rdr["Name"].ToString();

                    Team team = new Team(id, name);

                    TeamList.Add(team);

                }
                return TeamList;
            }
        }

        public Team GetTeamById(int TeamId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = " SELECT * FROM [Team] Where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", TeamId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Team team = null;

                while (rdr.Read())
                {
                    team = new Team(TeamId, rdr["Name"].ToString());
                }
                return team;
            }
        }

        public int CountTeamsByName(string TeamName)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT count(*) FROM [Team] Where Name = @TeamName";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@TeamName", TeamName);

                con.Open();
                int count = (Int32)cmd.ExecuteScalar();

                return count;
            }
        }

        public bool InsertTeam(Team Team)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO [Team] (Name) " +
                    "VALUES (@Name)";

                command.Parameters.AddWithValue("@Name", Team.Name);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;

            }

        }

        public bool UpdateTeam(Team Team)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "UPDATE [Team] SET Name = @TeamName Where Id = @id";

                command.Parameters.AddWithValue("@TeamName", Team.Name);
                command.Parameters.AddWithValue("@id", Team.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;

            }

        }

        public bool DeleteTeam(int TeamId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                string sqlQuery = " Delete From [Team] where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Id", TeamId);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
        }
    }
}

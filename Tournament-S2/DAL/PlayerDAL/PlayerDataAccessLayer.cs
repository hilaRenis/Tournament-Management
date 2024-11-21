using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.PlayerDAL
{
    public class PlayerDataAccessLayer : IPlayerRepository
    {
        private readonly IConfiguration configuration;

        public PlayerDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Player> GetPlayers()
        {
            List<Player> playerList = new List<Player>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Player].Id as PlayerId,[Player].Name as PlayerName, [Nationality].Id as NationalityId, " +
                    "[Nationality].Name as Nationality,DateOfBirth,TeamId,[Team].Name as TeamName " +
                    "FROM [Player] inner join [Team] on [Player].TeamId = [Team].Id " +
                    "INNER JOIN [Nationality] on [Player].NationalityId = [Nationality].Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Team team = new Team(Convert.ToInt32(rdr["TeamId"]), rdr["TeamName"].ToString());
                    Player player = new Player(Convert.ToInt32(rdr["PlayerId"]), rdr["PlayerName"].ToString(), Convert.ToInt32(rdr["NationalityId"]),
                                              rdr["Nationality"].ToString(), Convert.ToDateTime(rdr["DateOfBirth"]), team);
                    playerList.Add(player);
                }
                return playerList;
            }
        }

        public Player GetPlayerById(int playerId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Player].Id as PlayerId,[Player].Name as PlayerName ,[Nationality].Id as NationalityId," +
                    "[Nationality].Name as Nationality, DateOfBirth,TeamId,[Team].Name as TeamName " +
                    "FROM [Player] inner join [Team] on [Player].TeamId = [Team].Id " +
                    "inner join [Nationality] on [Player].NationalityId = [Nationality].Id " +
                    "Where [Player].Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", playerId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Player player = new Player();

                while (rdr.Read())
                {
                    Team team = new Team(Convert.ToInt32(rdr["TeamId"]), rdr["TeamName"].ToString());
                    player = new Player(Convert.ToInt32(rdr["PlayerId"]), rdr["PlayerName"].ToString(), Convert.ToInt32(rdr["NationalityId"]),
                        rdr["Nationality"].ToString(), Convert.ToDateTime(rdr["DateOfBirth"]), team);
                }
                return player;
            }
        }

        public bool InsertPlayer(Player Player)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO [Player] (Name, NationalityId, DateOfBirth, TeamId) " +
                    "VALUES (@name, @nationalityId, @dateOfBirth, @teamId)";

                command.Parameters.AddWithValue("@name", Player.Name);
                command.Parameters.AddWithValue("@nationalityId", Player.NationalityId);
                command.Parameters.AddWithValue("@dateOfBirth", Player.DateOfBirth);
                command.Parameters.AddWithValue("@teamId", Player.Team.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }
        }

        public bool UpdatePlayer(Player Player)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "UPDATE [Player] SET Name = @name, NationalityId = @nationality," +
                    "DateOfBirth = @dateOfBirth, TeamId = @teamId Where Id = @id";

                command.Parameters.AddWithValue("@name", Player.Name);
                command.Parameters.AddWithValue("@nationality", Player.NationalityId);
                command.Parameters.AddWithValue("@dateOfBirth", Player.DateOfBirth);
                command.Parameters.AddWithValue("@teamId", Player.Team.Id);
                command.Parameters.AddWithValue("@id", Player.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }

        public bool DeletePlayer(int playerId)
        {

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                string sqlQuery = " Delete From [Player] where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Id", playerId);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;

            }

        }
    }
}

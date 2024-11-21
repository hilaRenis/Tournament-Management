using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enum;
using BLL.Models;
using BLL.Interfaces;
using System.Reflection;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.TournamentDAL
{
    public class TournamentDataAccessLayer : ITournamentRepository
    {
        private readonly IConfiguration configuration;
        public TournamentDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournamentList = new List<Tournament>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = " SELECT [Tournament].Id, [Tournament].TournamentName, [Tournament].PrizePool, [Tournament].EntryFee, [Tournament].UserId, [Tournament].TournamentTypeId, [TournamentType].Name as TournamentType " +
                    " FROM [Tournament] inner join [TournamentType] on [Tournament].TournamentTypeId = [TournamentType].Id ";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string tournamentName = rdr["TournamentName"].ToString();
                    int tournamentTypeId = Convert.ToInt32(rdr["TournamentTypeId"]);
                    string tournamentType = rdr["TournamentType"].ToString();
                    int entryFee = Convert.ToInt32(rdr["EntryFee"]);
                    string prizePool = rdr["PrizePool"].ToString();

                    Tournament tournament = new Tournament(id,tournamentName, entryFee, prizePool, tournamentTypeId, tournamentType, 0);

                    tournamentList.Add(tournament);
                }
                return tournamentList;
            }
        }

        public List<Tournament> GetTournamentsByUserId(int userId)
        {
            List<Tournament> tournamentList = new List<Tournament>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Tournament].Id, [Tournament].TournamentName, [Tournament].PrizePool, [Tournament].EntryFee, [Tournament].UserId, [Tournament].TournamentTypeId, [TournamentType].Name AS TournamentType " +
                    "FROM [Tournament] INNER JOIN [TournamentType] ON [Tournament].TournamentTypeId = [TournamentType].Id " +
                    "WHERE [Tournament].UserId = @UserId";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string tournamentName = rdr["TournamentName"].ToString();
                    int tournamentTypeId = Convert.ToInt32(rdr["TournamentTypeId"]);
                    string tournamentType = rdr["TournamentType"].ToString();
                    int entryFee = Convert.ToInt32(rdr["EntryFee"]);
                    string prizePool = rdr["PrizePool"].ToString();

                    Tournament tournament = new Tournament(id, tournamentName, entryFee, prizePool, tournamentTypeId, tournamentType, userId);

                    tournamentList.Add(tournament);
                }
            }

            return tournamentList;
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Tournament].Id, [Tournament].TournamentName, [Tournament].PrizePool, [Tournament].EntryFee, [Tournament].UserId, [Tournament].TournamentTypeId, [TournamentType].Name AS TournamentType " +
                    "FROM [Tournament] INNER JOIN [TournamentType] ON [Tournament].TournamentTypeId = [TournamentType].Id " +
                    "WHERE [Tournament].Id = @Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", tournamentId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["Id"]);
                    string tournamentName = rdr["TournamentName"].ToString();
                    int tournamentTypeId = Convert.ToInt32(rdr["TournamentTypeId"]);
                    string tournamentType = rdr["TournamentType"].ToString();
                    int entryFee = Convert.ToInt32(rdr["EntryFee"]);
                    string prizePool = rdr["PrizePool"].ToString();
                    int userId = Convert.ToInt32(rdr["UserId"]);

                    Tournament tournament = new Tournament(id, tournamentName, entryFee, prizePool, tournamentTypeId, tournamentType, userId);

                    return tournament;
                }

                return null;
            }
        }

        public int CountTournamentsByName(string tournamentName)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT count(*) FROM [Tournament] Where TournamentName = @tournamentName";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@tournamentName", tournamentName);

                con.Open();
                int count = (Int32)cmd.ExecuteScalar();

                return count;
            }
        }

        public bool InsertTournament(Tournament tournament, int userId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO [Tournament] (TournamentName, EntryFee, TournamentTypeId, PrizePool, UserId) " +
                    "VALUES (@tournamentName, @entryFee, @tournamentTypeId,@prizePool, @user)";

                command.Parameters.AddWithValue("@tournamentName", tournament.TournamentName);
                command.Parameters.AddWithValue("@entryFee", tournament.EntryFee);
                command.Parameters.AddWithValue("@tournamentTypeId", tournament.TournamentTypeId);
                command.Parameters.AddWithValue("@prizePool", tournament.PrizePool);
                command.Parameters.AddWithValue("@user", userId);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }

        public bool UpdateTournament(Tournament tournament)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "UPDATE [Tournament] SET TournamentName = @tournamentName," +
                    "EntryFee = @entryFee, TournamentTypeId = @tournamentTypeId, PrizePool = @prizePool Where Id = @id";

                command.Parameters.AddWithValue("@tournamentName", tournament.TournamentName);
                command.Parameters.AddWithValue("@entryFee", tournament.EntryFee);
                command.Parameters.AddWithValue("@tournamentTypeId", tournament.TournamentTypeId);
                command.Parameters.AddWithValue("@prizePool", tournament.PrizePool);
                command.Parameters.AddWithValue("@id", tournament.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }

        public bool DeleteTournament(int tournamentId)
        {

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                string sqlQuery = "Delete From [Tournament] where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Id", tournamentId);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }
    }
}

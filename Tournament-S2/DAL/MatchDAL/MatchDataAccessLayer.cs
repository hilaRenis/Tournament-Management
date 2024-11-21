using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MatchDAL
{
    public class MatchDataAccessLayer : IMatchRepository
    {
        private readonly IConfiguration configuration;
        public MatchDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Matches> GetMatches()
        {
            List<Matches> matchList = new List<Matches>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Match].Id as MatchId,DateOfMatch,[Tournament].Id as TournamentId,[TournamentName]," +
                    " [t1].Id as Team1Id,[t1].Name as Team1,[t2].Id as Team2Id,[t2].Name as Team2, l.Id as LocationId, l.Name as LocationName " +
                    " from [Match] inner join [Tournament] on [Match].TournamentId = [Tournament].Id" +
                    " inner join [Team] as t1 on [Match].Team1Id = [t1].Id" +
                    " inner join [Team] as t2 on [Match].Team2Id = [t2].Id" +
                    " inner join [Location] as l on [Match].LocationId = [l].Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["MatchId"]);
                    DateTime dateOfMatch = Convert.ToDateTime(rdr["DateOfMatch"]);
                    int tournamentId = Convert.ToInt32(rdr["TournamentId"]);
                    string tournamentName = rdr["TournamentName"].ToString();
                    int team1Id = Convert.ToInt32(rdr["Team1Id"]);
                    string team1 = rdr["Team1"].ToString();
                    int team2Id = Convert.ToInt32(rdr["Team2Id"]);
                    string team2 = rdr["Team2"].ToString();
                    int locationId = Convert.ToInt32(rdr["LocationId"]);
                    string locationName = rdr["LocationName"].ToString();

                    Matches matches = new Matches(id, dateOfMatch, tournamentId, tournamentName, team1Id, team1, team2Id, team2, locationId , locationName);
                    matchList.Add(matches);

                }
                return matchList;
            }
        }

        public Matches GetMatchById(int matchId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT [Match].Id as MatchId,DateOfMatch,[Tournament].Id as TournamentId,[TournamentName]," +
                   " [t1].Id as Team1Id,[t1].Name as Team1,[t2].Id as Team2Id,[t2].Name as Team2, l.Id as LocationId, l.Name as LocationName" +
                   " from [Match] inner join [Tournament] on [Match].TournamentId = [Tournament].Id" +
                   " inner join [Team] as t1 on [Match].Team1Id = [t1].Id" +
                   " inner join [Team] as t2 on [Match].Team2Id = [t2].Id " +
                   " inner join [Location] as l on [Match].LocationId = [l].Id" +
                   " where [Match].Id = @matchId";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@matchId", matchId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Matches match = new Matches();

                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["MatchId"]);
                    DateTime dateOfMatch = Convert.ToDateTime(rdr["DateOfMatch"]);
                    int tournamentId = Convert.ToInt32(rdr["TournamentId"]);
                    string tournamentName = rdr["TournamentName"].ToString();
                    int team1Id = Convert.ToInt32(rdr["Team1Id"]);
                    string team1 = rdr["Team1"].ToString();
                    int team2Id = Convert.ToInt32(rdr["Team2Id"]);
                    string team2 = rdr["Team2"].ToString();
                    int locationId = Convert.ToInt32(rdr["LocationId"]);
                    string locationName = rdr["LocationName"].ToString();

                    match = new Matches(id, dateOfMatch, tournamentId, tournamentName, team1Id, team1, team2Id, team2, locationId, locationName);
                }
                return match;
            }
        }

        public bool InsertMatch(Matches match)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO [Match] (DateOfMatch, LocationId, TournamentId, Team1Id, Team2Id) " +
                    "VALUES (@dateOfMatch, @location, @tournamentId, @team1Id, @team2Id)";

                command.Parameters.AddWithValue("@dateOfMatch", match.DateOfMatch);
                command.Parameters.AddWithValue("@location", match.LocationId);
                command.Parameters.AddWithValue("@tournamentId", match.TournamentId);
                command.Parameters.AddWithValue("@team1Id", match.Team1Id);
                command.Parameters.AddWithValue("@team2Id", match.Team2Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }
        }

        public bool UpdateMatch(Matches Match)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "UPDATE [Match] SET DateOfMatch = @dateOfMatch, LocationId = @location," +
                    "TournamentId = @tournamentId, Team1Id = @team1Id, Team2Id = @team2Id Where Id = @id";

                command.Parameters.AddWithValue("@dateOfMatch", Match.DateOfMatch);
                command.Parameters.AddWithValue("@location", Match.LocationId);
                command.Parameters.AddWithValue("@tournamentId", Match.TournamentId);
                command.Parameters.AddWithValue("@team1Id", Match.Team1Id);
                command.Parameters.AddWithValue("@team2Id", Match.Team2Id);
                command.Parameters.AddWithValue("@id", Match.Id);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }

        public bool DeleteMatch(int matchId)
        {
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                string sqlQuery = "Delete From [Match] where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Id", matchId);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }

        }
    }
}

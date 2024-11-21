using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Matches
    {
        public Matches() { }

        public Matches(int id) 
        {
            Id = id;
        }

        public Matches(int id, DateTime dateOfMatch, int tournamentId, string tournamentName, int team1Id, string team1, int team2Id, string team2, int locationId, string locationName)
        {
            Id = id;
            DateOfMatch = dateOfMatch;
            SetLocationName(locationName);
            LocationId = locationId;
            TournamentId = tournamentId;
            SetTournamentName(tournamentName);
            Team1Id = team1Id;
            SetTeam1(team1);
            Team2Id = team2Id;
            SetTeam2(team2);
        }

        public Matches(int id, DateTime dateOfMatch, int tournamentId, string tournamentName, int team1Id, string team1, int team2Id, string team2, int locationId)
        {
            Id = id;
            DateOfMatch = dateOfMatch;
            LocationId = locationId;
            TournamentId = tournamentId;
            SetTournamentName(tournamentName);
            Team1Id = team1Id;
            SetTeam1(team1);
            Team2Id = team2Id;
            SetTeam2(team2);
        }

        public Matches(int id, DateTime dateOfMatch, int tournamentId, int team1Id, string team1, int team2Id, string team2, int locationId)
        {
            Id = id;
            DateOfMatch = dateOfMatch;
            LocationId = locationId;
            TournamentId = tournamentId;
            Team1Id = team1Id;
            SetTeam1(team1);
            Team2Id = team2Id;
            SetTeam2(team2);
        }

        public int Id { get; private set; }

        [Required]
        public DateTime DateOfMatch { get; private set; }

        public int LocationId { get; private set; }

        [Required]
        public string LocationName { get; private set; }

        [Required]
        public int TournamentId { get; private set; }

        public string TournamentName { get; private set; }

        public int Team1Id { get; private set; }

        public string Team1 { get; private set; }

        public int Team2Id { get; private set; }

        public string Team2 { get; private set; }

        public void SetTournamentName(string tournamentName)
        {
            if (string.IsNullOrWhiteSpace(tournamentName))
            {
                throw new ArgumentException("Tournament name is required");
            }

            TournamentName = tournamentName.Trim();
        }

        public void SetTeam1(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException("Team name is required");
            }

            Team1 = teamName.Trim();
        }

        public void SetTeam2(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException("Team name is required");
            }

            Team2 = teamName.Trim();
        }

        public void SetLocationName(string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                throw new ArgumentException("Location name is required");
            }
            LocationName = locationName.Trim();
        }
    }
}

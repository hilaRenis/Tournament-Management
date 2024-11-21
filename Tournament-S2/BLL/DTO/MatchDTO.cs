using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MatchDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the date of the match.")]
        public DateTime DateOfMatch { get; set; }

        public int LocationId { get; set; }

        [Required(ErrorMessage = "Please enter the location of the match.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please select a tournament.")]
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        public int Team1Id { get; set; }

        [Required(ErrorMessage = "Please select Team 1.")]
        public string Team1 { get; set; }

        public int Team2Id { get; set; }

        [Required(ErrorMessage = "Please select Team 2.")]
        public string Team2 { get; set; }

        public List<MatchDTO> Match { get; set; }

        public MatchDTO() { }

        public MatchDTO(Matches matches)
        {
            Id = matches.Id;
            DateOfMatch = matches.DateOfMatch;
            LocationId = matches.LocationId;
            Location = matches.LocationName;
            TournamentId = matches.TournamentId;
            TournamentName = matches.TournamentName;
            Team1Id = matches.Team1Id;
            Team1 = matches.Team1;
            Team2Id = matches.Team2Id;
            Team2 = matches.Team2;
            Match = new List<MatchDTO>();
        }
    }
}

using BLL.Enum;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TournamentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the tournament.")]
        public string TournamentName { get; set; }

        [Required(ErrorMessage = "Please enter the entry fee of the tournament.")]
        [Range(1, int.MaxValue, ErrorMessage = "Value shouldn't be less than 1")]

        public int EntryFee { get; set; }

        [Required(ErrorMessage = "Please enter the prize pool of the tournament.")]
        [Range(1, int.MaxValue, ErrorMessage = "Value shouldn't be less than 1")]

        public string PrizePool { get; set; }

        public int TournamentTypeId { get; set; }

        [Required(ErrorMessage = "Please enter the type of the tournament.")]
        public string TournamentTypeName { get; set; }

        public int UserId { get; set; }

        public TournamentDTO() { }

        public TournamentDTO(Tournament model) 
        {
            Id = model.Id;
            TournamentName = model.TournamentName;
            EntryFee = model.EntryFee;
            PrizePool = model.PrizePool;
            TournamentTypeId = model.TournamentTypeId;
            TournamentTypeName = model.TournamentTypeName;
            UserId = model.UserId;
        }
    }
}

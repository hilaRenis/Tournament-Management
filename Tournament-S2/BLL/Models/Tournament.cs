using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enum;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class Tournament
    {
        public int Id { get; private set; }

        [Required]
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; private set; }

        [Required]
        [Display(Name = "Entry Fee")]
        [Range(1, int.MaxValue, ErrorMessage = "Value shouldn't be less than 1")]
        public int EntryFee { get; private set; }

        [Required]
        [Display(Name = "Prize Pool")]
        [Range(1, int.MaxValue, ErrorMessage = "Value shouldn't be less than 1")]
        public string PrizePool { get; private set; }

        public int TournamentTypeId { get; private set; }

        [Required]
        public string TournamentTypeName { get; private set; }

        public int UserId { get; private set; }

        public Tournament() { }

        public Tournament(int id)
        {
            Id = id;
        }

        public Tournament(int tournamentId, string tournamentName, int entryFee, string prizePool, int tournamentTypeId, string tournamentTypeName, int userId)
        {
            Id = tournamentId;
            SetTournamentName(tournamentName);
            SetEntryFee(entryFee);
            SetPrizePool(prizePool);
            TournamentTypeId = tournamentTypeId;
            TournamentTypeName = tournamentTypeName;
            SetUserId(userId);
        }

        public Tournament(int tournamentId, string tournamentName, int entryFee, string prizePool, int tournamentTypeId, int userId)
        {
            Id = tournamentId;
            SetTournamentName(tournamentName);
            SetEntryFee(entryFee);
            SetPrizePool(prizePool);
            TournamentTypeId = tournamentTypeId;
            SetUserId(userId);
        }

        public void SetTournamentName(string tournamentName)
        {
            if (string.IsNullOrWhiteSpace(tournamentName))
                throw new ArgumentException("Tournament name is required");
            TournamentName = tournamentName.Trim();
        }

        public void SetEntryFee(int entryFee)
        {
            if (entryFee < 0)
                throw new ArgumentException("Entry fee cannot be negative");
            EntryFee = entryFee;
        }

        public void SetPrizePool(string prizePool)
        {
            if (string.IsNullOrWhiteSpace(prizePool))
                throw new ArgumentException("Prize pool is required");
            PrizePool = prizePool.Trim();
        }

        public void SetUserId(int userId)
        {
            if (userId < 0)
                throw new ArgumentException("User ID is required");
            UserId = userId;
        }
    }
}

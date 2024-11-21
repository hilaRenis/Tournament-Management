using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TournamentTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of tournament type.")]
        public string Name { get; set; }

        public TournamentTypeDTO() { }

        public TournamentTypeDTO(TournamentType tournamentType)
        {
            Id = tournamentType.Id;
            Name = tournamentType.Name;
        }
    }
}

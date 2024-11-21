using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the player.")]
        public string Name { get; set; }

        public int NationalityId { get; set; }

        [Required(ErrorMessage = "Please enter the nationality of the player.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter the age of the player.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter the team of the player.")]
        public TeamDTO TeamDTO { get; set; }

        public PlayerDTO() { }

        public PlayerDTO (Player player) 
        {
            Id = player.Id;
            Name = player.Name;
            NationalityId = player.NationalityId;
            Nationality = player.Nationality;
            DateOfBirth = player.DateOfBirth;
            TeamDTO = new TeamDTO(player.Team);
        }
    }
}

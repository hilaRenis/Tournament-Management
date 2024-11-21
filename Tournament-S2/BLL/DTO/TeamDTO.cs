using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the team.")]
        public string Name { get; set; }

        public TeamDTO() { }

        public TeamDTO(Team model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}

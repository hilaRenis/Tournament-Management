using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of location.")]
        public string Name { get; set; }

        public LocationDTO() { }

        public LocationDTO(Location location) 
        {
            Id = location.Id;
            Name = location.Name;
        }
    }
}

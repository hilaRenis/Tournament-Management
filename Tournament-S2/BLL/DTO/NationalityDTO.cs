using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.DTO
{
    public class NationalityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the nationality.")]
        public string Name { get; set; }

        public NationalityDTO() { }

        public NationalityDTO(Nationality nationality)
        {
            Id = nationality.Id;
            Name = nationality.Name;
        }
    }
}

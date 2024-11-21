using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Location
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public Location() { }

        public Location(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

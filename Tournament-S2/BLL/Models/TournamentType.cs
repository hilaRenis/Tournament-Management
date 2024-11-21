using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TournamentType
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public TournamentType() { }

        public TournamentType (int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

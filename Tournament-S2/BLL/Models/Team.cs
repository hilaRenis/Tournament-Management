using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Team
    {
        public Team() { }

        public Team(int id) 
        {
            Id = id;
        }

        public Team(int id, string name)
        {
            Id = id;
            SetName(name);
        }

        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Team name is required");
            Name = name.Trim();
        }
    }
}

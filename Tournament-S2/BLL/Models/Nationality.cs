using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Nationality
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Nationality() { }

        public Nationality(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

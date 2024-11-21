using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_DAL
{
    public class FakeLocationDBMediator : ILocationRepository
    {
        private List<Location> locations;

        public FakeLocationDBMediator()
        {
            this.locations = new List<Location>();
            locations.Add(new Location(1, "Air Albania"));
            locations.Add(new Location(2, "Selman Stermasi"));
        }

        public List<Location> GetAllLocation()
        {
            return this.locations;
        }
    }
}

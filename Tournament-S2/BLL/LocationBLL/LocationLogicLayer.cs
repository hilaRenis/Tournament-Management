using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LocationBLL
{
    public class LocationLogicLayer
    {
        private readonly ILocationRepository locationRepository;

        public LocationLogicLayer(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public List<Location> GetAllLocation()
        {
            List<Location> locationList = new List<Location>();

            locationList = locationRepository.GetAllLocation();

            return locationList;
        }
    }
}

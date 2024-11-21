using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.NationalityBLL
{
    public class NationalityLogicLayer
    {
        private readonly INationalityRepository nationalityRepository;

        public NationalityLogicLayer(INationalityRepository nationalityRepository)
        {
            this.nationalityRepository = nationalityRepository;
        }

        public List<Nationality> GetAllNationalities()
        {
            List<Nationality> nationalitiesList = new List<Nationality>();

            nationalitiesList = nationalityRepository.GetAllNationalities();

            return nationalitiesList;
        }
    }
}

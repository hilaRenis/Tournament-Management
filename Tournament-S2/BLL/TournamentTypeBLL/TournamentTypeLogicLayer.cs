using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.TournamentTypeBLL
{
    public class TournamentTypeLogicLayer
    {
        private readonly ITournamentTypeRepository tournamentTypeRepository;

        public TournamentTypeLogicLayer(ITournamentTypeRepository tournamentTypeRepository)
        {
            this.tournamentTypeRepository = tournamentTypeRepository;
        }

        public List<TournamentType> GetAllTournamentType()
        {
            List<TournamentType> tournamentTypeList = new List<TournamentType>();

            tournamentTypeList = tournamentTypeRepository.GetAllTournamentType();

            return tournamentTypeList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITournamentRepository
    {
        public List<Tournament> GetTournaments();
        public List<Tournament> GetTournamentsByUserId(int userId);
        public Tournament GetTournamentById(int tournamentId);
        public int CountTournamentsByName(string tournamentName);
        public bool InsertTournament(Tournament tournament, int userId);
        public bool UpdateTournament(Tournament tournament);
        public bool DeleteTournament(int tournamentId);
    }
}

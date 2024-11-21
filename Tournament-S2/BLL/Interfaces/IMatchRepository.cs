using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMatchRepository
    {
        public List<Matches> GetMatches();

        public Matches GetMatchById(int matchId);

        public bool InsertMatch(Matches match);

        public bool UpdateMatch(Matches Match);

        public bool DeleteMatch(int matchId);
    }
}

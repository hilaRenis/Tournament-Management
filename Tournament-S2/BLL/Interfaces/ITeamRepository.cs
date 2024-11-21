using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITeamRepository
    {
        public List<Team> GetTeams();
        public Team GetTeamById(int TeamId);
        public int CountTeamsByName(string TeamName);
        public bool InsertTeam(Team Team);
        public bool UpdateTeam(Team Team);
        public bool DeleteTeam(int TeamId);
    }
}

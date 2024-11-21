using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Enum;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BLL.Interfaces;

namespace BLL.TeamBLL
{
    public class TeamLogicLayer
    {
        private readonly ITeamRepository teamRepository;

        public TeamLogicLayer(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public List<Team> GetAllTeams()
        {
            List<Team> TeamList = new List<Team>();
            TeamList = teamRepository.GetTeams();

            return TeamList;
        }

        public bool AddNewTeam(Team Team)
        {
            int count = teamRepository.CountTeamsByName(Team.Name);
            if (count == 0)
            {
                return teamRepository.InsertTeam(Team);
            }

            return false;
        }

        public Team GetTeamById(Team team)
        {
            return teamRepository.GetTeamById(team.Id);
        }

        public bool UpdateTeam(Team Team)
        {
            return teamRepository.UpdateTeam(Team);
        }

        public bool DeleteTeam(Team team)
        {
            return teamRepository.DeleteTeam(team.Id);
        }
    }
}

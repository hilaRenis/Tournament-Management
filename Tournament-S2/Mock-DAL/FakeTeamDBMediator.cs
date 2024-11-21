using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Interfaces;

namespace Mock_DAL
{
    public class FakeTeamDBMediator : ITeamRepository
    {
        private List<Team> teams;

        public FakeTeamDBMediator()
        {
            this.teams = new List<Team>();
        }

        public int CountTeamsByName(string name)
        {
            int count = 0;
            foreach (Team team in this.teams)
            {
                if (team.Name == name)
                    count++;
            }

            return count;
        }

        public bool InsertTeam(Team team)
        {
            if (team == null)
            {
                return false;
            }

            this.teams.Add(team);
            return true;
        }

        public bool DeleteTeam(int teamId)
        {
            if (GetTeamById(teamId) != null)
            {
                return this.teams.Remove(GetTeamById(teamId));
            }

            return false;
        }

        public Team GetTeamById(int teamId)
        {
            foreach (Team team in this.teams)
            {
                if (team.Id == teamId)
                    return team;
            }

            return null;
        }

        public List<Team> GetTeams()
        {
            return this.teams;
        }

        public bool UpdateTeam(Team newTeam)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Id == newTeam.Id)
                {
                    teams[i] = newTeam;
                    return true;
                }
            }

            return false;
        }
    }
}

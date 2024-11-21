using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Mock_DAL
{
    public class FakeTournamentDBMediator : ITournamentRepository
    {
        private List<Tournament> tournaments;

        public FakeTournamentDBMediator()
        {
            this.tournaments = new List<Tournament>();
        }

        public int CountTournamentsByName(string tournamentName)
        {
            int count = 0;
            foreach (Tournament tournament in this.tournaments)
            {
                if (tournament.TournamentName == tournamentName)
                    count++;
            }

            return count;
        }

        public bool DeleteTournament(int tournamentId)
        {
            if (GetTournamentById(tournamentId) != null)
            {
                return this.tournaments.Remove(GetTournamentById(tournamentId));
            }

            return false;
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            foreach (Tournament tournament in this.tournaments)
            {
                if (tournament.Id == tournamentId)
                    return tournament;
            }

            return null;
        }

        public List<Tournament> GetTournaments()
        {
            return this.tournaments;
        }

        public List<Tournament> GetTournamentsByUserId(int userId)
        {
            List<Tournament> tournamentsByUserId = new List<Tournament>();
            foreach (Tournament tournament in this.tournaments)
            {
                if (tournament.UserId == userId)
                    tournamentsByUserId.Add(tournament);
            }

            return tournamentsByUserId;
        }

        public bool InsertTournament(Tournament tournament, int userId)
        {
            if (CountTournamentsByName(tournament.TournamentName) > 0)
                return false;

            this.tournaments.Add(tournament);
            return true;
        }

        public bool UpdateTournament(Tournament newTournament)
        {
            for (int i = 0; i < tournaments.Count; i++)
            {
                if (tournaments[i].Id == newTournament.Id)
                {
                    tournaments[i] = newTournament;
                    return true;
                }
            }

            return false;
        }
    }
}

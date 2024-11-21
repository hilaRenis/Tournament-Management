using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_DAL
{
    public class FakeMatchDBMediator : IMatchRepository
    {
        private List<Matches> matches;
        private ITournamentRepository tournamentRepository;
        private ILocationRepository locationRepository;
        private ITeamRepository teamRepository;

        public FakeMatchDBMediator()
        {
            this.matches = new List<Matches>();
            this.tournamentRepository = new FakeTournamentDBMediator();
            this.locationRepository = new FakeLocationDBMediator();
            this.teamRepository = new FakeTeamDBMediator();
        }

        public bool DeleteMatch(int matchId)
        {
            if (GetMatchById(matchId) != null)
            {
                return this.matches.Remove(GetMatchById(matchId));
            }

            return false;
        }

        public List<Matches> GetMatches()
        {
            return this.matches;
        }

        public Matches GetMatchById(int matchId)
        {
            foreach (Matches match in this.matches)
            {
                if (match.Id == matchId)
                    return match;
            }

            return new Matches();
        }

        public bool InsertMatch(Matches match)
        {
            if (match == null)
            {
                return false;
            }

            this.matches.Add(match);
            return true;
        }

        public bool UpdateMatch(Matches match)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Id == match.Id)
                {
                    matches[i] = match;
                    return true;
                }
            }

            return false;
        }

        public bool GenerateRoundRobinMatches(Tournament selectedTournament)
        {
            List<Team> teams = teamRepository.GetTeams();
            var random = new Random();

            if (teams.Count < 2)
            {
                return false; // Cannot generate matches with less than 2 teams 
            }

            int totalRounds = teams.Count - 1;
            int matchesPerRound = teams.Count / 2;

            for (int round = 0; round < totalRounds; round++)
            {
                for (int matchIndex = 0; matchIndex < matchesPerRound; matchIndex++)
                {
                    int team1Index = (round + matchIndex) % (teams.Count - 1);
                    int team2Index = (teams.Count - 1 - matchIndex + round) % (teams.Count - 1);

                    if (matchIndex == 0)
                    {
                        team2Index = teams.Count - 1;
                    }

                    Team team1 = teams[team1Index];
                    Team team2 = teams[team2Index];
                    Location locationRandom = GetRandomLocation(random);
                    DateTime matchDate = GetRandomDate(random);

                    Matches match = new Matches(0, matchDate, selectedTournament.Id, team1.Id, team1.Name, team2.Id, team2.Name, locationRandom.Id);
                    InsertMatch(match);
                }
            }

            return true;
        }

        private DateTime GetRandomDate(Random random)
        {
            DateTime today = DateTime.Today;
            int daysToAdd = random.Next(1, 31); // Generate a random number of days between 1 and 30
            int minutesToAdd = random.Next(0, 1441);  // Generate a random number of minutes between 0 and 1440 (24 hours)

            DateTime randomDateTime = today.AddDays(daysToAdd).AddMinutes(minutesToAdd);

            return randomDateTime;
        }

        private Location GetRandomLocation(Random random)
        {
            var locations = locationRepository.GetAllLocation();
            if (locations.Count == 0)
            {
                throw new Exception("No locations found.");
            }

            int randomIndex = random.Next(locations.Count);
            return locations[randomIndex];
        }
    }
}

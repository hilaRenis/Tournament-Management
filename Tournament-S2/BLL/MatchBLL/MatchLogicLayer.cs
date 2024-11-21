using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MatchBLL
{
    public class MatchLogicLayer
    {
        private readonly IMatchRepository matchRepository;
        private readonly ITournamentRepository tournamentRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ITeamRepository teamRepository; 
        public MatchLogicLayer(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        public MatchLogicLayer(IMatchRepository matchRepository, ITournamentRepository tournamentRepository, ILocationRepository locationRepository, ITeamRepository teamRepository)
        {
            this.matchRepository = matchRepository;
            this.tournamentRepository = tournamentRepository;
            this.locationRepository = locationRepository;
            this.teamRepository = teamRepository;
        }

        public List<Matches> GetAllMatches()
        {
            List<Matches> matchList = new List<Matches>();

            matchList = matchRepository.GetMatches();

            return matchList;
        }

        public bool AddNewMatch(Matches match)
        {
            // Step 1: Check if the match is in the future
            if (match.DateOfMatch.Date < DateTime.Today)
            {
                return false;
            }

            // Step 2: Check for overlap with existing matches
            var existingMatches = matchRepository.GetMatches();
            foreach (var existingMatch in existingMatches)
            {
                if (existingMatch.DateOfMatch.Date == match.DateOfMatch.Date
                    && existingMatch.Team1 == match.Team1
                    && existingMatch.Team2 == match.Team2)
                {
                    return false; // There is an overlap
                }
            }

            // Step 3: Insert the match
            return matchRepository.InsertMatch(match);
        }

        public Matches GetMatchById(Matches match)
        {
            return matchRepository.GetMatchById(match.Id);
        }

        public bool UpdateMatch(Matches match)
        {
            if (match.DateOfMatch.Date < DateTime.Today)
            {
                return false; // Cannot update match that has already occurred
            }

            var existingMatch = matchRepository.GetMatchById(match.Id);
            if (existingMatch.DateOfMatch.Date < DateTime.Today)
            {
                return false; // Cannot change date of match that has already occurred
            }

            return matchRepository.UpdateMatch(match);
        }

        public bool DeleteMatch(Matches match)
        {
            return matchRepository.DeleteMatch(match.Id);
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
                    matchRepository.InsertMatch(match);
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

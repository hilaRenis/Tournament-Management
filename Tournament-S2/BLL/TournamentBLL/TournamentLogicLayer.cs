using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Enum;
using BLL.Interfaces;

namespace BLL.TournamentBLL
{
    public class TournamentLogicLayer
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly ITournamentTypeRepository tournamentTypeRepository;

        public TournamentLogicLayer(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public TournamentLogicLayer(ITournamentRepository tournamentRepository, ITournamentTypeRepository tournamentTypeRepository)
        {
            this.tournamentRepository = tournamentRepository;
            this.tournamentTypeRepository = tournamentTypeRepository;
        }

        public List<Tournament> GetAllTournaments(Users user)
        {
            List<Tournament> tournamentList = new List<Tournament>();

            if (user.Role == Role.USER)
            {
                tournamentList = tournamentRepository.GetTournamentsByUserId(user.Id);
            }
            else
            {
                tournamentList = tournamentRepository.GetTournaments();
            }

            return tournamentList;
        }

        public bool AddNewTournament(Tournament tournament, Users user)
        {
            int count = tournamentRepository.CountTournamentsByName(tournament.TournamentName);

            if (count == 0)
            {
                return tournamentRepository.InsertTournament(tournament, user.Id);
            }

            return false;
        }

        public Tournament GetTournamentById(Tournament tournament)
        {
            return tournamentRepository.GetTournamentById(tournament.Id);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            return tournamentRepository.UpdateTournament(tournament);
        }

        public bool DeleteTournament(Tournament tournament)
        {
            return tournamentRepository.DeleteTournament(tournament.Id);
        }

        public bool GenerateAutomaticTournament(Users user) 
        {
            var random = new Random();
            string uniqueTournamentName = GenerateRandomTournamentName(random);

            if (uniqueTournamentName == null)
            {
                Console.WriteLine("All tournament names are already taken.");
                return false;
            }

            string randomPrize = random.Next(1000, 10000).ToString(); // Set a random prize between 1000 and 10000
            int randomEntryFee = random.Next(1000, 10000); // Set a random fee between 1000 and 10000
            TournamentType randomType = GetRandomTournamentType(random); // Get a random tournament type

            tournamentRepository.InsertTournament(new Tournament(0, uniqueTournamentName, randomEntryFee, randomPrize, randomType.Id, user.Id), user.Id);
            Console.WriteLine($"Generated tournament '{uniqueTournamentName}'");

            return true;
        }

        private string GenerateRandomTournamentName(Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int nameLength = random.Next(8, 12); // Generate a name with a length between 8 and 12 characters

            string randomTournamentName = new string(Enumerable.Repeat(chars, nameLength)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());

            List<string> tournamentNames = new List<string> { randomTournamentName };

            string uniqueTournamentName = GetUniqueTournamentName(tournamentNames);
            return uniqueTournamentName;
        }

        private string GetUniqueTournamentName(List<string> tournamentNames)
        {
            var random = new Random();
            int randomIndex = random.Next(tournamentNames.Count);

            string randomTournamentName = tournamentNames[randomIndex];
            if (tournamentRepository.CountTournamentsByName(randomTournamentName) == 0)
            {
                return randomTournamentName;
            }

            return null;
        }

        private TournamentType GetRandomTournamentType(Random random)
        {
            var tournamentTypes = tournamentTypeRepository.GetAllTournamentType();
            if (tournamentTypes.Count == 0)
            {
                throw new Exception("No tournament types found.");
            }

            int randomIndex = random.Next(tournamentTypes.Count);

            return tournamentTypes[randomIndex];
        }
    }
}

using BLL.Models;
using BLL.Enum;
using Mock_DAL;
using BLL.TournamentBLL;
using BLL.Utils;

namespace UnitTests.TournamentTests
{
    [TestClass]
    public class TournamentTest 
    {
        // 1.Testing positive scenarios
        [TestMethod]
        public void AddTournamentTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.USER, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            bool result = tournamentLogicLayer.AddNewTournament(tournament, user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetTournamentByIdTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);

            Tournament tournament2 = new Tournament(1);
            Tournament foundTournament = tournamentLogicLayer.GetTournamentById(tournament2);

            Assert.AreEqual(tournament, foundTournament);
        }

        [TestMethod]
        public void DeleteTournamentTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);

            bool result = tournamentLogicLayer.DeleteTournament(tournament);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetTournamentTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament1 = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);
            Tournament tournament2 = new Tournament(2, "Tournament2", 2000, "Prize2", 2, 1);

            tournamentLogicLayer.AddNewTournament(tournament1, user);
            tournamentLogicLayer.AddNewTournament(tournament2, user);


            List<Tournament> allTournamentsFound = tournamentLogicLayer.GetAllTournaments(user);

            CollectionAssert.AreEqual(new List<Tournament> { tournament1, tournament2 }, allTournamentsFound);
        }

        [TestMethod]
        public void UpdateTeamTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);

            Tournament updatedTournament = new Tournament(1, "Tournament15", 10500, "Prize1", 2, 1);
            tournamentLogicLayer.UpdateTournament(updatedTournament);

            List<Tournament> newList = tournamentLogicLayer.GetAllTournaments(user);

            Assert.AreEqual(updatedTournament.Id, newList[0].Id);
            Assert.AreEqual(updatedTournament.TournamentName, newList[0].TournamentName);
            Assert.AreEqual(updatedTournament.EntryFee, newList[0].EntryFee);
            Assert.AreEqual(updatedTournament.PrizePool, newList[0].PrizePool);
            Assert.AreEqual(updatedTournament.TournamentTypeId, newList[0].TournamentTypeId);
            Assert.AreEqual(updatedTournament.UserId, newList[0].UserId);
        }

        // 2.Testing negative scenarios  
        [TestMethod]
        public void AddTournamentTest_TournamentAlreadyExists()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.USER, PasswordHash.GenerateSalt());
            Tournament existingTournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);
            tournamentLogicLayer.AddNewTournament(existingTournament, user);

            Tournament newTournament = new Tournament(2, "Tournament1", 500, "Prize2", 2, 1);
            bool result = tournamentLogicLayer.AddNewTournament(newTournament, user);

            Assert.IsFalse(result);  //Tournament with the same name already exist
        }

        [TestMethod]
        public void GetTournamentById_NotFound_Test()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);
            Tournament tournament2 = new Tournament(2);
            Tournament foundTournament = tournamentLogicLayer.GetTournamentById(tournament2);


            Assert.IsNull(foundTournament); // Tournament with Id=2 does not exist
        }

        [TestMethod]
        public void DeleteTournament_NotFound_Test()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);

            Tournament tournament2 = new Tournament(2);
            bool result = tournamentLogicLayer.DeleteTournament(tournament2);

            Assert.IsFalse(result); // Tournament with Id=2 does not exist
        }

        [TestMethod]
        public void UpdateTournamentWithInvalidTournamentTest()
        {
            TournamentLogicLayer tournamentLogicLayer = new TournamentLogicLayer(new FakeTournamentDBMediator());
            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Tournament tournament = new Tournament(1, "Tournament1", 1000, "Prize1", 1, 1);

            tournamentLogicLayer.AddNewTournament(tournament, user);

            Tournament updatedTournament = new Tournament(2, "Tournament15", 10500, "Prize1", 2, 1);
            tournamentLogicLayer.UpdateTournament(updatedTournament);

            List<Tournament> newList = tournamentLogicLayer.GetAllTournaments(user);

            Assert.AreNotEqual(updatedTournament.Id, newList[0].Id); // Nonexistent tournament ID
        }
    }
}

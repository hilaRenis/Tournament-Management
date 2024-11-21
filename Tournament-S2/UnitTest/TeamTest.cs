using BLL.Enum;
using BLL.Models;
using BLL.TeamBLL;
using BLL.UserBLL;
using Mock_DAL;

namespace UnitTests.TeamTests
{
    [TestClass]
    public class TeamTest
    {
        // 1.Testing positive scenarios
        [TestMethod]
        public void InsertTeamTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");

            bool result = teamLogicLayer.AddNewTeam(team1);
            Team foundTeam = teamLogicLayer.GetTeamById(team1);

            Assert.IsTrue(result);
            Assert.AreEqual(team1, foundTeam);
        }

        [TestMethod]
        public void DeleteTeamTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");
            teamLogicLayer.AddNewTeam(team1);

            bool result = teamLogicLayer.DeleteTeam(team1);
            Team deletedTeam = teamLogicLayer.GetTeamById(team1);

            Assert.IsTrue(result);
            Assert.IsNull(deletedTeam);
        }

        [TestMethod]
        public void GetTeamByIdTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");
            teamLogicLayer.AddNewTeam(team1);

            Team foundTeam = teamLogicLayer.GetTeamById(team1);

            Assert.AreEqual(team1, foundTeam);
        }

        [TestMethod]
        public void GetTeamsTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");
            Team team2 = new Team(2, "Real Madrid");
            teamLogicLayer.AddNewTeam(team1);
            teamLogicLayer.AddNewTeam(team2);

            List<Team> teams = teamLogicLayer.GetAllTeams();

            Assert.AreEqual(2, teams.Count);
            Assert.AreEqual(team1, teams[0]);
            Assert.AreEqual(team2, teams[1]);
        }

        [TestMethod]
        public void UpdateTeamTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");
            teamLogicLayer.AddNewTeam(team1);

            Team newTeam = new Team(1, "Real Madrid");
            bool result = teamLogicLayer.UpdateTeam(newTeam);
            Team updatedTeam = teamLogicLayer.GetTeamById(newTeam);

            Assert.IsTrue(result);
            Assert.AreEqual(newTeam, updatedTeam);
        }

        // 2.Testing negative scenarios  
        [TestMethod]
        public void CreateTeamTest_WithExistingTeamName_ReturnsFalse()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team = new Team(1, "Barcelona");
            teamLogicLayer.AddNewTeam(team);

            //Attempt to create a new team with the same name
            Team newTeam = new Team(2, "Barcelona");
            bool result = teamLogicLayer.AddNewTeam(newTeam);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteNonExistingTeamTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team = new Team(1, "Barcelona");

            bool result = teamLogicLayer.DeleteTeam(team);

            Assert.IsFalse(result); //Team being deleted does not exist
        }

        [TestMethod]
        public void GetTeamBy_NonExistingIdTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());

            Team team1 = new Team(1, "Barcelona");
            

            Team foundTeam = teamLogicLayer.GetTeamById(team1);

            Assert.IsNull(foundTeam); // Team with Id= 1 doesn't exist
        }

        [TestMethod]
        public void UpdateTeamNotFoundTest()
        {
            TeamLogicLayer teamLogicLayer = new TeamLogicLayer(new FakeTeamDBMediator());
            Team team1 = new Team(1, "Barcelona");
            teamLogicLayer.AddNewTeam(team1);

            Team newTeam = new Team(2, "Real Madrid");
            bool result = teamLogicLayer.UpdateTeam(newTeam);
            Team updatedTeam = teamLogicLayer.GetTeamById(newTeam);

            Assert.IsFalse(result);
            Assert.IsNull(updatedTeam); // There is no Team with an ID of 2
        }
    }
}

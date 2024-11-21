using BLL.Enum;
using BLL.LocationBLL;
using BLL.MatchBLL;
using BLL.Models;
using BLL.TeamBLL;
using BLL.TournamentBLL;
using BLL.Utils;
using Mock_DAL;
using System.Text.RegularExpressions;

namespace MatchTests 
{
    [TestClass]
    public class MatchTest 
    {
        // 1.Testing positive scenarios
        [TestMethod]
        public void AddMatch()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga",1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");

            bool result = matchLogicLayer.AddNewMatch(match);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMatchById()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");
            matchLogicLayer.AddNewMatch(match);

            Matches foundMatch = matchLogicLayer.GetMatchById(match);

            Assert.AreEqual(match, foundMatch);
        }

        [TestMethod]
        public void DeleteMatch()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");
            matchLogicLayer.AddNewMatch(match);

            bool result = matchLogicLayer.DeleteMatch(match);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMatches()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match1 = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");
            Matches match2 = new Matches(2, DateTime.Now, 1, "SuperLiga", 3, "Teuta KF", 4, "Laci KF", 3, "SelmanStermasi");
            matchLogicLayer.AddNewMatch(match1);
            matchLogicLayer.AddNewMatch(match2);

            List<Matches> allMatchesFound = matchLogicLayer.GetAllMatches();

            CollectionAssert.AreEqual(new List<Matches> { match1, match2 }, allMatchesFound);
        }

        [TestMethod]
        public void UpdateMatch()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");
            matchLogicLayer.AddNewMatch(match);
            Matches updatedMatch = new Matches(1, DateTime.Now.AddDays(1), 1, "French League", 3, "PSG", 2, "Lyon", 1, "SelmanStermasi");

            bool result = matchLogicLayer.UpdateMatch(updatedMatch);
            List<Matches> newList = matchLogicLayer.GetAllMatches();

            Assert.IsTrue(result);
            Assert.AreEqual(1, newList.Count);
            Assert.AreSame(updatedMatch, newList[0]);
            Assert.AreNotSame(match, newList[0]);
        }

        [TestMethod]
        public void GenerateRoundRobinMatches_WithDataSaved()
        {
            // Create fake data for teams, tournaments, and matchLogicLayer
            var tournament1 = new Tournament(1, "Tournament", 1000, "Prize", 1, 1);

            var teams = new[]
            {
                new Team(1, "Team a"),
                new Team(2, "Team b"),
                new Team(3, "Team c"),
                new Team(4, "Team d")
            };

            var fakeTournamentDBMediator = new FakeTournamentDBMediator();
            fakeTournamentDBMediator.InsertTournament(tournament1, 1);

            var fakeTeamDBMediator = new FakeTeamDBMediator();
            foreach (var team in teams)
            {
                fakeTeamDBMediator.InsertTeam(team);
            }

            var matchLogicLayer = new MatchLogicLayer(
                new FakeMatchDBMediator(),
                fakeTournamentDBMediator,
                new FakeLocationDBMediator(),
                fakeTeamDBMediator
            );

            // Generate matches 
            matchLogicLayer.GenerateRoundRobinMatches(tournament1);
            var matches = matchLogicLayer.GetAllMatches();
            Assert.AreEqual(6, matches.Count); // Assuming a round-robin tournament with 4 teams, there should be 6 matches generated
        }

        [TestMethod]
        public void GenerateRoundRobinMatches_CheckEachTeamPlaysOnce()
        {
            // Create fake data for teams, tournaments, and matchLogicLayer
            var tournament = new Tournament(1, "Tournament", 1000, "Prize", 1, 1);

            var teams = new[]
            {
                new Team(1, "Team a"),
                new Team(2, "Team b"),
                new Team(3, "Team c"),
                new Team(4, "Team d")
            };

            var fakeTournamentDBMediator = new FakeTournamentDBMediator();
            fakeTournamentDBMediator.InsertTournament(tournament, 1);

            var fakeTeamDBMediator = new FakeTeamDBMediator();
            foreach (var team in teams)
            {
                fakeTeamDBMediator.InsertTeam(team);
            }

            var fakeMatchDBMediator = new FakeMatchDBMediator();

            var matchLogicLayer = new MatchLogicLayer(
                fakeMatchDBMediator,
                fakeTournamentDBMediator,
                new FakeLocationDBMediator(),
                fakeTeamDBMediator
            );

            // Generate matches
            matchLogicLayer.GenerateRoundRobinMatches(tournament);
            var matches = matchLogicLayer.GetAllMatches();

            // Check that each team plays against each other only once
            foreach (var team1 in teams)
            {
                foreach (var team2 in teams)
                {
                    if (team1 != team2)
                    {
                        var count = matches.Count(match =>
                            (match.Team1Id == team1.Id && match.Team2Id == team2.Id) ||
                            (match.Team1Id == team2.Id && match.Team2Id == team1.Id)
                        );
                        Assert.AreEqual(1, count, $"Team {team1.Name} should play against Team {team2.Name} exactly once.");
                    }
                }
            }

        }

        // 2.Testing negative scenarios
        [TestMethod]
        public void InsertMatch_NullMatchTest()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = null;

            bool result = false;
            if (match != null)
            {
                result = matchLogicLayer.AddNewMatch(match);
            }

            Assert.IsFalse(result); // Match is null so will not be added
        }

        [TestMethod]
        public void GetMatchById_NonExistentMatchTest()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");

            Matches result = matchLogicLayer.GetMatchById(match);

            Assert.AreEqual(result.Id, 0); // The method should return a match object with ID 0 when the match does not exist
        }

        [TestMethod]
        public void DeleteNonExistentMatchTest()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");

            bool result = matchLogicLayer.DeleteMatch(match);

            Assert.IsFalse(result); // Delete a match with ID 1 does not exist
        }

        [TestMethod]
        public void UpdateMatchNotFoundTest()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator());
            Matches match = new Matches(1, DateTime.Now, 1, "SuperLiga", 1, "Tirona KF", 2, "Partizani KF", 2, "AirAlbania");
            matchLogicLayer.AddNewMatch(match);

            Matches updatedMatch = new Matches(2, DateTime.Now.AddDays(1), 1, "French League", 3, "PSG", 2, "Lyon", 1, "SelmanStermasi");
            bool result = matchLogicLayer.UpdateMatch(updatedMatch);
            List<Matches> newList = matchLogicLayer.GetAllMatches();

            Assert.IsFalse(result);
            Assert.AreEqual(1, newList.Count);
            Assert.AreSame(match, newList[0]);
            Assert.AreNotSame(updatedMatch, newList[0]); // Try to update a match with ID = 2, which does not exist in the list
        }

        [TestMethod]
        public void GenerateRoundRobinMatches_NoDataSaved()
        {
            MatchLogicLayer matchLogicLayer = new MatchLogicLayer(new FakeMatchDBMediator(), new FakeTournamentDBMediator(), new FakeLocationDBMediator(),
                                                              new FakeTeamDBMediator());
            var tournament = new Tournament(1, "Tournament", 1000, "Prize", 1, 1);

            // Generate matches
            matchLogicLayer.GenerateRoundRobinMatches(tournament);

            List<Matches> matches = matchLogicLayer.GetAllMatches();

            Assert.AreEqual(0, matches.Count); // It should not generate matches when there are no teams, tournament, or location saved
        }
    }
}
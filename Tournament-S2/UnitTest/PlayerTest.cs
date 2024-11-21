using Mock_DAL;
using BLL.Models;
using BLL.PlayerBLL;
using System.Globalization;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTest 
    {
        // 1.Testing positive scenarios
        [TestMethod]
        public void AddPlayerTest()  
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());

            Team team = new Team(1,"Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1,"Player1",1, birthDate, team);

            bool result = playerLogicLayer.AddNewPlayer(player); 

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetPlayerByIdTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());

            Team team = new Team(1, "Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);

            playerLogicLayer.AddNewPlayer(player);

            Player foundPlayer = playerLogicLayer.GetPlayerById(player);

            Assert.AreEqual(player, foundPlayer);
        }

        [TestMethod]
        public void DeletePlayerTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());

            Team team = new Team(1, "Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);

            playerLogicLayer.AddNewPlayer(player);

            bool result = playerLogicLayer.DeletePlayer(player);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetPlayersTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());

            Team team1 = new Team(1, "Barcelona");
            Team team2 = new Team(2, "Real Madrid");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player1 = new Player(1, "Player1", 1, birthDate, team1);
            Player player2 = new Player(2, "Player2", 2, birthDate, team2);

            playerLogicLayer.AddNewPlayer(player1);
            playerLogicLayer.AddNewPlayer(player2);


            List<Player> allPlayersFound = playerLogicLayer.GetAllPlayers();

            CollectionAssert.AreEqual(new List<Player> { player1, player2 }, allPlayersFound);
        }

        [TestMethod]
        public void UpdateMatchTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());

            Team team = new Team(1, "Barcelona");
            Team team2 = new Team(2, "Real Madrid");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime birthDate2 = DateTime.ParseExact("02-02-2001", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);

            playerLogicLayer.AddNewPlayer(player);

            Player updatedPlayer = new Player(1, "Player8", 2, birthDate2, team2);

            bool result = playerLogicLayer.UpdatePlayer(updatedPlayer);
            List<Player> newList = playerLogicLayer.GetAllPlayers();

            Assert.IsTrue(result);
            Assert.AreEqual(1, newList.Count);
            Assert.AreSame(updatedPlayer, newList[0]);
            Assert.AreNotSame(player, newList[0]);
        }

        // 2.Testing negative scenarios
        [TestMethod]
        public void AddPlayer_NullPlayerTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());
            Player player = null;

            bool result = playerLogicLayer.AddNewPlayer(player);

            Assert.IsFalse(result);// Player is null so will not be added
        }

        [TestMethod]
        public void GetPlayerById_NonExistentPlayerTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());
            Team team = new Team(1, "Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);

            Player foundPlayer = playerLogicLayer.GetPlayerById(player);

            Assert.IsNull(foundPlayer); // Player with Id=1 doesn't exist
        }

        [TestMethod]
        public void DeleteNonExistentPlayerTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());
            Team team = new Team(1, "Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);

            bool result = playerLogicLayer.DeletePlayer(player);

            Assert.IsFalse(result); // Delete a player with ID = 1  does not exist
        }

        [TestMethod]
        public void UpdatePlayerNotFoundTest()
        {
            PlayerLogicLayer playerLogicLayer = new PlayerLogicLayer(new FakePlayerDBMediator());
            Team team = new Team(1, "Barcelona");
            DateTime birthDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player player = new Player(1, "Player1", 1, birthDate, team);
            playerLogicLayer.AddNewPlayer(player);

            DateTime birthDate2 = DateTime.ParseExact("02-02-2001", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Player updatedPlayer = new Player(2, "Player8", 2, birthDate2, team); // Changed the ID to 2, which does not exist in the list

            bool result = playerLogicLayer.UpdatePlayer(updatedPlayer);
            List<Player> newList = playerLogicLayer.GetAllPlayers();

            Assert.IsFalse(result); // Updated assertion to expect false
            Assert.AreEqual(1, newList.Count);
            Assert.AreSame(player, newList[0]);
            Assert.AreNotSame(updatedPlayer, newList[0]);
        }
    }
}
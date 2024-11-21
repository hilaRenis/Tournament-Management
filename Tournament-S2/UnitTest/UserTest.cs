using BLL.Enum;
using Mock_DAL;
using BLL.Models;
using BLL.UserBLL;
using BLL.Utils;

namespace UnitTests.UserTests
{
    [TestClass]
    public class UserTest
    {
        // 1. Testing positive scenarios
        [TestMethod]
        public void CreateUserTest()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());

            bool result1 = userLogicLayer.CreateUser(user1);

            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());

            userLogicLayer.CreateUser(user1);

            bool result1 = userLogicLayer.DeleteUser(user1);

            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void GetUserTest()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());

            userLogicLayer.CreateUser(user1);

            Users foundUser1 = userLogicLayer.GetUser(user1);

            Assert.AreEqual(user1, foundUser1);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());
            var user1 = new Users(1, "johndoe", "John", "Doe", "password", Role.USER, PasswordHash.GenerateSalt());

            userLogicLayer.CreateUser(user1);

            var foundUser1 = userLogicLayer.GetUserById(user1);

            Assert.AreEqual(user1, foundUser1);
        }

        [TestMethod]
        public void GetUsers_ReturnsListOfUsers_Success()
        {
            var mediator = new FakeUserDBMediator();
            var userLogicLayer = new UserLogicLayer(mediator);
            var user1 = new Users(1, "johndoe", "John", "Doe", "password", Role.USER, PasswordHash.GenerateSalt());
            var user2 = new Users(2, "janedoe", "Jane", "Doe", "password", Role.USER, PasswordHash.GenerateSalt());

            mediator.CreateUser(user1);
            mediator.CreateUser(user2);

            var result = userLogicLayer.GetAllUsers();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(user1, result[0]);
            Assert.AreEqual(user2, result[1]);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            Users user2 = new Users(2, "John", "Doe", "jdoe", "456", Role.USER, PasswordHash.GenerateSalt());

            userLogicLayer.CreateUser(user1);
            userLogicLayer.CreateUser(user2);
            Users updatedUser = new Users(2, "John", "Doe", "newusername", "456", Role.USER, PasswordHash.GenerateSalt());
            bool result = userLogicLayer.UpdateUser(updatedUser);
            Assert.IsTrue(result);

            Users foundUser = userLogicLayer.GetUserById(user2);
            Assert.AreEqual(updatedUser, foundUser);
        }

        // 2.Testing negative scenarios
        [TestMethod]
        public void CreateUserTest_WithExistingUserName_ReturnsFalse()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            var user = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            userLogicLayer.CreateUser(user);

            // Attempt to create a new user with the same username
            var newUser = new Users(2, "Test", "User", "rhila", "456", Role.USER, PasswordHash.GenerateSalt());
            bool result = userLogicLayer.CreateUser(newUser);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteUserTest_WithNonExistingUser_ReturnsFalse()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());

            bool result1 = userLogicLayer.DeleteUser(user1);

            Assert.IsFalse(result1); //User being deleted does not exist
        }

        [TestMethod]
        public void UpdateUserTest_WithNonExistentUser_ReturnsFalse()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());

            Users user1 = new Users(1, "Renis", "Hila", "rhila", "123", Role.ADMIN, PasswordHash.GenerateSalt());
            userLogicLayer.CreateUser(user1);

            Users updatedUser = new Users(2, "John", "Doe", "newusername", "456", Role.USER, PasswordHash.GenerateSalt());
            bool result = userLogicLayer.UpdateUser(updatedUser);

            Assert.IsFalse(result); //Trying to update a non-existent user
        }

        [TestMethod]
        public void GetUserByIdTest_UserNotFound_ReturnsNull()
        {
            UserLogicLayer userLogicLayer = new UserLogicLayer(new FakeUserDBMediator());
            var user1 = new Users(1, "johndoe", "John", "Doe", "password", Role.USER, PasswordHash.GenerateSalt());

            var foundUser2 = userLogicLayer.GetUserById(user1);

            Assert.IsNull(foundUser2); //User with Id=1 does not exist
        }
    }
}

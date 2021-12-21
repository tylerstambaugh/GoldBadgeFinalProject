using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ChallengeThree.Lib;
using System.Reflection;


namespace ChallengeThree.Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private static readonly BadgeRepo _badgeRepo = new BadgeRepo();

        [TestMethod]
        public void CreateBadge_GeneralTest_ReturnsTrue()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e3", "r4", "t5" };
            Badge testBadge3 = new Badge(3, listOfDoors);

            //act
            bool wasAdded = _badgeRepo.CreateBadge(testBadge3);

            //assert
            Assert.IsTrue(wasAdded);
           // Assert.AreEqual(_badgeRepo.CountOfBadges(), 1);
        }

        [TestMethod]
        public void GetAllBadges_GeneralTest_ReturnsTrue()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e3", "r4", "t5" };
            Badge testBadge = new Badge(1, listOfDoors);
            Badge testBadge2 = new Badge(2, listOfDoors);            

            //act
            _badgeRepo.CreateBadge(testBadge);
            _badgeRepo.CreateBadge(testBadge2);
            Dictionary<int, List<string>> allBadges = _badgeRepo.GetAllBadges();

            //assert
            Assert.IsTrue(allBadges.ContainsKey(1));
            Assert.IsTrue(allBadges.ContainsKey(2));
        }

        [TestMethod]
        public void AddDoorToBadge_GeneralTest_ReturnsTrue()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e3", "r4", "t5" };
            Badge testBadge = new Badge(1, listOfDoors);
            _badgeRepo.CreateBadge(testBadge);
            //act
            bool wasAdded = _badgeRepo.AddDoorToBadge(1, "y6");
            //assert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_GeneralTest_ReturnsTrue()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e4", "r5", "t6" };
            Badge testBadge2 = new Badge(2, listOfDoors);
            _badgeRepo.CreateBadge(testBadge2);
            //act
            bool wasRemoved = _badgeRepo.RemoveDoorFromBadge(2, "r4");
            //assert
            Assert.IsTrue(wasRemoved);

        }

        [TestMethod]
        public void RemoveAllDoorsFromBadge_GeneralTest_ReturnsTrue()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e4", "r5", "t6" };
            Badge testBadge3 = new Badge(3, listOfDoors);
            _badgeRepo.CreateBadge(testBadge3);
            //act 
            int countOfDoorsBeforeRemoving = _badgeRepo.GetCountOfDoorsOnBadge(3);
            _badgeRepo.RemoveAllDoorsFromBadge(3);
            int countOfDoorsAfterRemoving = _badgeRepo.GetCountOfDoorsOnBadge(3);
            //assert
            Assert.AreEqual(3, countOfDoorsBeforeRemoving);
            Assert.AreEqual(0, countOfDoorsAfterRemoving);
        }

        [TestMethod]
        public void BadgeExists_GeneralTest_ReturnsFalse()
        {
            //arrange
            List<string> listOfDoors = new List<string>() { "e4", "r5", "t6" };
            Badge testBadge4 = new Badge(4, listOfDoors);
            _badgeRepo.CreateBadge(testBadge4);

            //act 
            bool badgeExist = _badgeRepo.BadgeExists(4);

            //assert
            Assert.IsTrue(badgeExist);
        }

        [TestMethod]
        public void BadgeExists_GeneralTest_ReturnsTrue()
        {
            //arrange

            //act
            bool badgeDoesNotExist = _badgeRepo.BadgeExists(-1);

            //assert
            Assert.IsFalse(badgeDoesNotExist);
        }
    }
}

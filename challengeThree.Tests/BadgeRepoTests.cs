using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ChallengeThree.Lib;

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
            Badge testBadge = new Badge(1, listOfDoors);

            //act
            bool wasAdded = _badgeRepo.CreateBadge(testBadge);

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

        }

        [TestMethod]
        public void RemoveAllDoorsFromBadge_GeneralTest_ReturnsTrue()
        {
            //arrange

            //act 

            //assert
        }

        [TestMethod]
        public void BadgeExists_GeneralTest_ReturnsFalse()
        {

        }

        [TestMethod]
        public void BadgeExists_GeneralTest_ReturnsTrue()
        {

        }
    }
}

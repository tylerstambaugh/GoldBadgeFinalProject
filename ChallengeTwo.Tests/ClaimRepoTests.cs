using ChallengeTwo.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo.Tests
{
    [TestClass]
    public class ClaimRepoTests
    {
        //going to write tests for each of the repo methods.
        //testm tab tab to stub out testmethod
        private static ClaimRepo _claimRepo = new ClaimRepo();
        
        [TestMethod]
        public void CreateClaim_GeneralTest_ReturnsTrue() //bool CreateClaim(Claim)
        {
            //Arrange:
            Claim testClaim = new Claim(1, (Claim.ClaimType)1, "TestClaim 1", 4250.00m, new DateTime(2021, 01, 15), new DateTime(2021, 12, 07), true);

            bool expected = true;

            //Act
            bool actual = _claimRepo.CreateClaim(testClaim);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetAllClaims_GeneralTest_ReturnsAQueueOfClaims() //queue GetAllClaims()
        {
            //Arrange
            Claim testClaim2 = new Claim(1, (Claim.ClaimType)1, "TestClaim 2", 4250.00m, new DateTime(2021, 01, 15), new DateTime(2021, 12, 07), true);
            _claimRepo.CreateClaim(testClaim2);

            //Act
            Queue<Claim> testQueue = _claimRepo.GetAllClaims();

            //Assert
            Assert.IsNotNull(testQueue);
        }

        [TestMethod]
        public void GetNextClaim_GeneralTest_ReturnsAClaim() 
        {
            //Arrange
            Claim testClaim3 = new Claim(1, (Claim.ClaimType)1, "TestClaim 3", 4250.00m, new DateTime(2021, 01, 15), new DateTime(2021, 12, 07), true);
            _claimRepo.CreateClaim(testClaim3);

            //Act
            Claim claimToTest = _claimRepo.GetNextClaim();

            //Assert
            Assert.IsNotNull(claimToTest);
        }

        [TestMethod]
        public void IsValidClaim_GeneralTest_ReturnsTrue()
        {
            //Arrange
            DateTime incidentDate = new DateTime(2021, 11, 30);
            DateTime claimDate = new DateTime(2021, 12, 01);
            //Act
            bool isTrue = _claimRepo.IsClaimValid(incidentDate, claimDate);
            //Assert
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void IsValidClaim_GeneralTest_ReturnsFalse()
        {
            //Arrange
            DateTime incidentDate = new DateTime(2021, 10, 30);
            DateTime claimDate = new DateTime(2021, 12, 01);
            //Act
            bool isFalse = _claimRepo.IsClaimValid(incidentDate, claimDate);
            //Assert
            Assert.IsFalse(isFalse);
        }

        [TestMethod]
        public void HandleClaim_GeneralTest_ReturnsTrue()
        {
            //Arrange
            Claim testClaim4 = new Claim(1, (Claim.ClaimType)1, "TestClaim 4", 4250.00m, new DateTime(2021, 01, 15), new DateTime(2021, 12, 07), true);
            _claimRepo.CreateClaim(testClaim4);
            //Act
            bool isTrue = _claimRepo.HandleClaim();
            //Assert
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void ReturnDate_HelperMethod_IsNotNull()
        {
            //Arrange
            string dateAsString = "01/01/2021";
            //Act
            DateTime dateTime = _claimRepo.ReturnDate(dateAsString);
            //Assert
            Assert.IsInstanceOfType(dateTime, typeof(DateTime));
        }
    }
}

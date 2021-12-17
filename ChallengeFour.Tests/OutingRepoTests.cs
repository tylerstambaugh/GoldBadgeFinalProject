using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChallengeFour.Lib;
using System.Collections.Generic;

namespace ChallengeFour.Tests
{
    [TestClass]
    public class OutingRepoTests
    {
        private readonly OutingRepo _outingRepo = new OutingRepo();

        [TestMethod]
        public void CreateOuting_GeneralTest_RetrunsTrue()
        {
            //arrange
            Outing outingToAdd = new Outing(Outing.OutingType.Golf, 12, new DateTime(01 / 01 / 2021), 123.32m, 23423.65m);
            //act
            bool wasAdded = _outingRepo.CreateOuting(outingToAdd);
            //asssert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetAllOutings_GeneralTest_AssertsListIsNotNull()
        {
            //arrange
            Outing outingToAdd2 = new Outing(Outing.OutingType.Golf, 12, new DateTime(01 / 01 / 2021), 123.32m, 23423.65m);
            _outingRepo.CreateOuting(outingToAdd2);
            //act
            List<Outing> allOutings = _outingRepo.GetAllOutings();

            //assert
            Assert.IsNotNull(allOutings);
        }

        [TestMethod]
        public void CalculateCostOfAllOutings_GeneralTest_AssertsAreEqual()
        {
            //arrange
            Outing outingToAdd3 = new Outing(Outing.OutingType.Bowling, 16, new DateTime(01 / 01 / 2021), 420.69m, 420.69m);
            _outingRepo.CreateOuting(outingToAdd3);
            //act
            decimal costOfAllOutings = _outingRepo.CalculateCostOfAllOutings();
            //assert
            Assert.AreEqual(420.69m, costOfAllOutings);
        }

        [TestMethod]
        public void CalculateCostOfAllOutingsOfType_GeneralTest_AssertsAreEqual()
        {
            //arrange
            Outing outingToAdd4 = new Outing(Outing.OutingType.Concert, 16, new DateTime(01 / 01 / 2021), 420.69m, 1345.00m);
            _outingRepo.CreateOuting(outingToAdd4);
            Outing outingToAdd5 = new Outing(Outing.OutingType.Concert, 16, new DateTime(01 / 01 / 2021), 420.69m, 2255.00m);
            _outingRepo.CreateOuting(outingToAdd5);
            //act
            decimal costOfAllOutingsOfType = _outingRepo.CalculateCostOfAllOutingsOfType(Outing.OutingType.Concert);
            //assert
            Assert.AreEqual(3600.00m, costOfAllOutingsOfType);
        }
    }
}

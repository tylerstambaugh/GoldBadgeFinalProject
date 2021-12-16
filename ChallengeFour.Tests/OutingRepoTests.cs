using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChallengeFour.Lib;

namespace ChallengeFour.Tests
{
    [TestClass]
    public class OutingRepoTests
    {
        private readonly OutingRepo _outingRepo = new OutingRepo();

        [TestMethod]
        public void TestMethod1()
        {
        }

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
    }
}

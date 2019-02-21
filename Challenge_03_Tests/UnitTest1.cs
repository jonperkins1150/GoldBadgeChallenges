using System;
using System.Collections.Generic;
using Challenge_03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_03_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OutingRepository_AddOuting_ShouldReturnCorrectCount()
        {
            //Arrange
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            //Act
            outingRepo.AddOuting(EventType.Golf, 5, DateTime.Today, 5m, 20m);
            var expected = 1;
            var actual = outingRepo.GetList().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void OutingRepository_TotalCost_ShouldReturnCorrecCost()
        {
            //Arrange
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            //Act
            outingRepo.AddOuting(EventType.Golf, 5, DateTime.Today, 5m, 20m);
            outingRepo.AddOuting(EventType.Golf, 5, DateTime.Today, 5m, 20m);
            var expected = 40m;
            var actual = outingRepo.TotalCost();
            //Assert
            Assert.AreEqual(expected, actual);
        } 
        [TestMethod]
        public void OutingRepository_GetCostByType_ShouldReturnCorrectCost()
        {
            //Arrange
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            //Act
            outingRepo.AddOuting(EventType.AmusementPark, 5, DateTime.Today, 5m, 150m);
            outingRepo.AddOuting(EventType.Bowling, 5, DateTime.Today, 5m, 30m);
            var expected = 150m;
            var actual = outingRepo.GetCostByType(EventType.AmusementPark);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}


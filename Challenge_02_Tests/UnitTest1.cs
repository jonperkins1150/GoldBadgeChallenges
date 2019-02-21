using System;
using System.Collections.Generic;
using Challenge_02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_02_Tests
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void ClaimRepository_GetClaims_ShouldReturnCorrectCount()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = new Queue<Claim>();
            //Act
            claimRepo.AddClaim(ClaimType.Theft, "Art theft", 30m, DateTime.Now, DateTime.Now);
            claimQueue = claimRepo.GetClaims();
            //Assert
            int expected = 1;
            int actual = claimQueue.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_AddClaim_ShouldReturnCorrectCOunt()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = new Queue<Claim>();
            //Act
            claimRepo.AddClaim(ClaimType.Theft, "Art Theft", 30m, DateTime.Now, DateTime.Now);
            claimQueue = claimRepo.GetClaims();
            int expected = 1;
            int actual = claimQueue.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_CountDown_ShouldReturnCorrectCount()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = new Queue<Claim>();
            claimRepo.CountDown();
            //Act
            claimRepo.AddClaim(ClaimType.Theft, "Art Theft", 30m, DateTime.Now, DateTime.Now);
            claimQueue = claimRepo.GetClaims();
            int expected = 0;
            int actual = claimRepo.claimCount;
 
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

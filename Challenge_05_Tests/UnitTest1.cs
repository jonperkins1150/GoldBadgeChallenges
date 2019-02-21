using System;
using System.Collections.Generic;
using Challenge_05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_05_Tests
{
    [TestClass]
    public class UnitTest1
    {
        CustomerRepository _customerRepoTest = new CustomerRepository();
        List<Customer> _customerList = new List<Customer>();

        [TestMethod]
        public void ClaimsRepository_AddCustomer_ShouldReturnCorrectCount()
        {
            //Arrange
            _customerRepoTest.AddCustomer("James", "Walker", 1);
            List<Customer> _customerList = _customerRepoTest.GetList();
            //Act           
            var actual = _customerList.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(actual, expected);
        }     
        [TestMethod]
        public void CustomerRepository_Recount_ShouldReturnCorrectCount()
        {
            //Arrange
            _customerRepoTest.AddCustomer("James", "Walker", 1);
            List<Customer> _customerList = _customerRepoTest.GetList();
            //Act           
            var actual = _customerList.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CustomerRepository_RemoveItemFromList_ShouldReturnCorrectCount()
        {
            //Arrange
            _customerRepoTest.AddCustomer("James", "Walker", 1);
            _customerRepoTest.AddCustomer("Jon", "Perkins", 1);
            _customerRepoTest.RemoveCustomer(1);
            List<Customer> _customerList = _customerRepoTest.GetList();
            //Act           
            var actual = _customerList.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using Challenge_05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_05_Tests
{

    [TestClass]
    public class UnitTest1
    {
        CustomerRepository _customerRepo = new CustomerRepository();
        public List<Customer> customerList = new List<Customer>();

        [TestMethod]
        public void ClaimsRepository_GetClaims_ShouldReturnCorrectCount()
        {
            CustomerRepository _customerRepoTest = new CustomerRepository();
            //Arrange

            List<Customer> customerTest = new List<Customer>();
            //_customerRepoTest.AddCustomer(Customer);
            //List<customer> menuList = _customerRepoTest.GetList();

            //Act           
            //var actual = menuList.Count;
            var expected = 1;

            //Assert
            //Assert.AreEqual(expected, actual);
            //_claimsrepo.AddClaim(ClaimType.Home, "Robbery", 1500.25m, DateTime.Now, DateTime.Now);


        }
    }
}

using System;
using System.Collections.Generic;
using Challenge_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_01_Tests
{
    [TestClass]
    public class UnitTest1
    {
        MenuRepository _menuRepoTest = new MenuRepository();
        public List<Menu> _menuList = new List<Menu>();

        [TestMethod]
        public void MenuRepository_AddNewItem_ShouldReturnCorrectCount()
        {
            //Arrange
            Menu menuItem = new Menu();
            _menuRepoTest.AddNewItem(menuItem);
            List<Menu> menuList = _menuRepoTest.GetMenu();       

            //Act           
            var actual = menuList.Count;
            var expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_SeedMenu_ShouldReturnCorrectCount()
        {
            //Arrange
            Menu menu = new Menu();
            _menuRepoTest.SeedMenu();
            List<Menu> menuList = _menuRepoTest.GetMenu();

            //Act           
            var actual = menuList.Count;
            var expected = 4;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MenuRepository_RemoveItemFromList_ShouldReturnCorrectCount()
        {
            //Arrange
            Menu menuItem = new Menu();
            _menuRepoTest.AddNewItem(menuItem);
            _menuRepoTest.AddNewItem(menuItem);
            _menuRepoTest.RemoveItemFromList(menuItem);
            List<Menu> menuList = _menuRepoTest.GetMenu();

            //Act           
            var actual = menuList.Count;
            var expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);

        }


    }
}

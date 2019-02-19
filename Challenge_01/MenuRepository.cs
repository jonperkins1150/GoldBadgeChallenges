using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    public class MenuRepository
    {
        public List<Menu> _menuList = new List<Menu>();

        public List<Menu> GetMenu()
        {
            return _menuList;
        }

        public void AddNewItem(Menu newMenuItem)
        {
            _menuList.Add(newMenuItem);
        }

        public void SeedMenu()
        {
            _menuList.Add(new Menu( 1, "SnglCheese", "Single Cheeseburger Meal", "Single, Fries and Drink",   7.99m));
            _menuList.Add(new Menu( 2, "DblCheese", "Double Cheeseburger Meal", "Double, Fries and Drink",   10.99m));
            _menuList.Add(new Menu( 3, "SnglBcnCheese", "Single Bacon Cheeseburger Meal", "Single, Bacon, Fries and Drink", 8.99m));
            _menuList.Add(new Menu( 4, "DblBcnCheese", "Double Bacon Cheeseburger Meal", "Double, Bacon, Fries and Drink", 11.99m));
        }

        public void RemoveItemFromList(Menu List)
        {
            _menuList.Remove(List);
        }
    }
}

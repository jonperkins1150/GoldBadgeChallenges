using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        int _response;
       

        internal void Run()
        {
            _menuRepo.SeedMenu();
             while (_response != 4)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        SeeAllItems();
                        break;
                    case 2:
                        AddMenuItem();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        Console.WriteLine("\n Have a Nice Day!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine(" \n Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddMenuItem()
        {
            Menu newMenuItem = new Menu();
            Console.Clear();
            SeeAllItems();
            Console.WriteLine("Enter the new Meal Number");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Meal Name");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter the new Meal Description");
            newMenuItem.MealDescription = Console.ReadLine();
            Console.WriteLine("Enter the new Meal Ingredients");
            newMenuItem.MealIngredients = Console.ReadLine();
            Console.WriteLine("Enter the new Meal Price");
            newMenuItem.MealPrice = decimal.Parse(Console.ReadLine());
            _menuRepo.AddNewItem(newMenuItem);
        }

        private void RemoveMenuItem()
        {
            SeeAllItems();
            Console.WriteLine("Enter the Number of the Meal you would like to remove:");
            int desiredNumber = int.Parse(Console.ReadLine());
            List<Menu> meals = _menuRepo.GetMenu();
            foreach (var item in meals)
            {
                if (desiredNumber == item.MealNumber)
                {
                    _menuRepo.RemoveItemFromList(item);
                    break;
                }
            }

        }

        private void SeeAllItems()
        {
            List<Menu> meals = _menuRepo.GetMenu();
            Console.Clear();
            Console.WriteLine("Meal# \t Meal Name \t\t Meal Description \t\t Meal Ingredients \t\t Meal Price\n");
            foreach (var item in meals)
                Console.WriteLine($"{item.MealNumber}\t{item.MealName} \t\t{item.MealDescription}\t{item.MealIngredients} \t $ {item.MealPrice}");
        }


        private void PrintMenu()
        {
            Console.WriteLine("Welcom to Komodo Restuarant \n\n");
            Console.WriteLine("What would you like to do? \n\t" +
                "1. See All Menu Items\n\t" +
                "2. Add Item to the Menu\n\t" +
                "3. Remove Item from the Menu\n\t" +
                "4. Exit");
            string responseStr = Console.ReadLine();
            _response = int.Parse(responseStr);
        }
    }
}

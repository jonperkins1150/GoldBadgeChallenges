using System;

namespace Challenge_03
{
    class ProgramUI
    {
        public OutingRepository _outingRepo = new OutingRepository();

        public static DateTime CreateDate(string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("   Month (MM): ");
            string monthAsString = Console.ReadLine();
            int month = int.Parse(monthAsString);
            Console.WriteLine("   Day (DD): ");
            string dayAsString = Console.ReadLine();
            int day = int.Parse(dayAsString);
            Console.WriteLine("   Year (YYYY): ");
            string yearAsString = Console.ReadLine();
            int year = int.Parse(yearAsString);
            DateTime newDate = new DateTime(year, month, day);
            return newDate;
        }
        public void Run()
        {
            StartMenu();
        }
        public void StartMenu()
        {
            bool continueToRunMenu = true;
            while (continueToRunMenu)
            {
                PrintMenu();
                int choice = GetAndParseInput(null);

                switch (choice)
                {
                    case 1:
                        ShowAllOutings();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        CalculateCosts();
                        break;
                    case 4:
                        continueToRunMenu = false;
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
        }
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do? \n\t" +
                "1. View all outings\n\t" +
                "2. Create new outing\n\t" +
                "3. Calculate costs\n\t" +
                "4. Exit");
        }
        public int GetAndParseInput(string textInput)
        {
            int choice = 0;
            Console.WriteLine(textInput);
            bool valid = false;
            while (!valid)
            {
                string choiceAsString = Console.ReadLine();
                if (int.TryParse(choiceAsString, out choice))
                    valid = true;
                else
                    Console.WriteLine("Invalid selection.");
            }
            return choice;
        }

        public void ShowAllOutings()
        {
            var outingList = _outingRepo.GetList();

            Console.Clear();
            if (outingList.Count == 0)
            {
                Console.WriteLine("There are currently no events recorded.");
            }
            else
            {
                foreach (Outing outing in outingList)
                {
                    Console.WriteLine(outing);
                }
            }
            Console.ReadLine();
        }
        public void AddOuting()
        {
            Console.Clear();
            Console.WriteLine("Select an outing type:\n\t" +
                "1. Amusement Park\n\t" +
                "2. Bowling\n\t" +
                "3. Concert\n\t" +
                "4. Golf");
            int input = int.Parse(Console.ReadLine());
            EventType newEvent = EventType.AmusementPark;
            string typeHeader = null;
            switch (input)
            {
                case 1:
                    newEvent = EventType.AmusementPark;
                    typeHeader = "Amusement Park Event";
                    break;
                case 2:
                    newEvent = EventType.Bowling;
                    typeHeader = "Bowling Event";
                    break;
                case 3:
                    newEvent = EventType.Concert;
                    typeHeader = "Concert Event";
                    break;
                case 4:
                    newEvent = EventType.Golf;
                    typeHeader = "Golf Event";
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
            Console.Clear();
            Console.WriteLine(typeHeader);
            Console.WriteLine("Enter the amount of attendees: ");
            int attendance = int.Parse(Console.ReadLine());
            var date = CreateDate("Enter the Month, Day, and Year of the event: ");
            Console.WriteLine("Enter the cost per individual for the event: $");
            decimal individualCost = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the total cost for the event: $");
            decimal totalEventCost = Decimal.Parse(Console.ReadLine());
            _outingRepo.AddOuting(newEvent, attendance, date, individualCost, totalEventCost);
            Console.ReadLine();
        }

        public void CalculateCosts()
        {
            Console.Clear();
            Console.WriteLine($"What calculations would you like to see? \n 1. Total cost for all outings \n 2. Total cost for outings of a specific type");
            string calcResponse = Console.ReadLine();
            if (calcResponse == "1")
            {
                Console.Clear();
                Console.WriteLine($"Total cost for all outings: ${_outingRepo.TotalCost()}");
            }
            else if (calcResponse == "2")
            {
                Console.Clear();
                Console.WriteLine("Enter the outing type would you like to sort by: \n\t" +
                    "1. Amusement Park\n\t" +
                    "2. Bowling\n\t" +
                    "3. Concert\n\t" +
                    "4. Golf");
                var typeNum = int.Parse(Console.ReadLine());
                EventType type = EventType.AmusementPark;
                switch (typeNum)
                {
                    case 1:
                        type = EventType.AmusementPark;
                        break;
                    case 2:
                        type = EventType.Bowling;
                        break;
                    case 3:
                        type = EventType.Concert;
                        break;
                    case 4:
                        type = EventType.Golf;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Console.Clear();
                Console.WriteLine($"Total cost for {type}: ${_outingRepo.GetCostByType(type)}");
            }
            Console.ReadLine();
        }
    }
}
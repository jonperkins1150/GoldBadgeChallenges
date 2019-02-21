using System;
using System.Collections.Generic;

namespace Challenge_05
{
    class ProgramUI
    {
        CustomerRepository customerRepo = new CustomerRepository();

        public void Run()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            List<Customer> customerList = customerRepo.GetList();
            customerRepo.AddCustomer("Jake", "Smith", 1);
            customerRepo.AddCustomer("James", "Smith", 2);
            customerRepo.AddCustomer("John", "Smith", 3);
         
            string input = null;
            while (input != "5")
            {
                Console.Clear();
                Console.WriteLine($"What would you like to do?\n\t" +
                    "1. Add New User\n\t" +
                    "2. View all Users\n\t" +
                    "3. Update User\n\t" +
                    "4. Remove User\n\t" +
                    "5. Exit");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Clear();
                    Console.Write("Add new user first name: ");
                    string newFirst = Console.ReadLine();
                    Console.Write("Add new user last name: ");
                    string newLast = Console.ReadLine();
                    Console.WriteLine($"Which type is this new user?\n\t" +
                        "1. Potential\n\t" +
                        "2. Current\n\t" +
                        "3. Past\n\t");
                    int valid = 0;
                    int newType = 1;
                    while (valid == 0)
                    {
                        newType = int.Parse(Console.ReadLine());
                        valid = 1;
                        switch (newType)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                valid = 0;
                                break;
                        }
                    }
                    customerRepo.AddCustomer(newFirst, newLast, newType);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    customerList.Sort((x, y) => string.Compare(x.LastName, y.LastName));
                    Console.WriteLine("UserID\tFirst\tLast\tCustomer Type\tEmail Sent");
                    customerRepo.Recount();
                    foreach (Customer customer in customerList)
                    {
                        string email = null;
                        switch (customer.Type)
                        {
                            case CustomerType.Potential:
                                email = "\tWe currently have the lowest rates on Helicopter Insurance!";
                                break;
                            case CustomerType.Current:
                                email = "\tThank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                                break;
                            case CustomerType.Past:
                                email = "\tIt's been a long time since we've heard from you, we want you back!";
                                break;
                        }
                        Console.WriteLine($"{customer} {email}");
                    }
                    Console.Read();
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.Write("Enter the customer ID you would like to update: ");
                    int response = int.Parse(Console.ReadLine());
                    if (customerList.Exists(x => x.UserID == response))
                    {
                        foreach (Customer customer in customerList)
                        {
                            if (customer.UserID == response)
                            {
                                Console.WriteLine($"1. First Name: {customer.FirstName}\n" +
                                    $"2. Last Name: {customer.LastName}\n" +
                                    $"3. Customer Type: {customer.Type}\n" +
                                    "4. Return to Menu\n" +
                                    "Enter the number to update: \n");
                                int updateResponse = int.Parse(Console.ReadLine());
                                switch (updateResponse)
                                {
                                    case 1:
                                        Console.Write("Enter new First Name: ");
                                        customer.FirstName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Enter new Last Name: ");
                                        customer.LastName = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new Customer Type: \n\t" +
                                            "1. Potential\n\t" +
                                            "2. Current\n\t" +
                                            "3. Past\n\t");
                                        int updatedType = int.Parse(Console.ReadLine());
                                        if (updatedType == 1)
                                            customer.Type = CustomerType.Potential;
                                        else if (updatedType == 2)
                                            customer.Type = CustomerType.Current;
                                        else if (updatedType == 3)
                                            customer.Type = CustomerType.Past;
                                        else
                                            Console.WriteLine("Invalid type.");
                                        break;
                                    case 4:
                                        Console.WriteLine("Press ENTER to return to main menu");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input");
                                        break;
                                }
                                break;
                            }
                        }
                    }
                    else
                        Console.WriteLine("No user exists with that ID.");
                    Console.ReadLine();
                }
                else if (input == "4")
                {
                    Console.Clear();
                    Console.Write("Enter the user's ID you would like to remove: ");
                    int response = int.Parse(Console.ReadLine());
                    if (customerList.Exists(x => x.UserID == response))
                    {
                        customerRepo.RemoveCustomer(response);
                        Console.WriteLine("User Removed.");
                    }
                    else
                        Console.WriteLine("No user exists with that ID.");
                    Console.ReadLine();
                }
                else if (input == "5")
                {
                    break;
                }
            }
            customerRepo.RemoveCustomer(2);
            foreach (Customer customer in customerList)
            {
                Console.WriteLine(customer.UserID);
            }
        }
    }
}

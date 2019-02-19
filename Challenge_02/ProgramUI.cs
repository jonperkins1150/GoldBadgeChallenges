using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Challenge_02
{

    class ProgramUI
    {
        ClaimsRepository _claimsRepo = new ClaimsRepository();
        int _response;
        

        internal void Run()
        {
            _claimsRepo.SeedMenu();
            while (_response != 4)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        ProcessNextClaim();
                        break;
                    case 3:
                        AddNewClaim();
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
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine($"Please Select An Option?\n\n\t" +
                    "1. View all claims\n\t" +
                    "2. Process next claim\n\t" +
                    "3. Enter new claim\n\t" +
                    "4. Exit");

        }

        private static DateTime CreateDate(string prompt)
        {
                 Console.WriteLine($"{prompt} (MM/DD/YYYY)");
                 string newDateString = Console.ReadLine();
                 DateTime newDate = DateTime.Parse(newDateString);

                 return newDate;
        }



        public void SeeAllClaims()
        {
            Queue<Claim> claimQueue = _claimsRepo.GetClaims();
            Console.Clear();

            Console.WriteLine("{0,-10} {1,-12} {2,-8} {3,-18} {4,-15} {5,-10} {6}", "Claim ID", "Claim Type", "Amount", "Date Of Accident", "Date Of Claim", "Is Valid", "Description");

            foreach (Claim claim in claimQueue)
            {

                Console.WriteLine(" {0,-10} {1,-12} ${2,-8} {3,-18} {4,-15} {5,-10} {6}", claim.ClaimID, claim.ClaimType, claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid, claim.Description);
            }
            Console.ReadLine();
        }

        public void ProcessNextClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();

            Console.Clear();
            if (claimQueue.Count != 0)
            {
                Claim topItem = claimQueue.Peek();
                Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                    $"  ClaimID: {topItem.ClaimID}\n" +
                    $"  Type: {topItem.ClaimType}\n" +
                    $"  Description: {topItem.Description}\n" +
                    $"  Amount: {topItem.ClaimAmount}\n" +
                    $"  DateOfIncident: {topItem.DateOfIncident.ToShortDateString()}\n" +
                    $"  DateOfClaim: {topItem.DateOfClaim.ToShortDateString()}\n" +
                    $"  IsValid: {topItem.IsValid}");

                while (true)
                {
                    Console.Write("Do you want to deal with this claim now? (y/n): ");
                    string delClaim = Console.ReadLine();
                    if (delClaim == "y")
                    {
                        claimQueue.Dequeue();
                        foreach (Claim claim in claimQueue)
                        {
                            claim.ClaimID--;
                        }
                        _claimRepo.CountDown();
                        Console.WriteLine("Claim processed.");
                        break;
                    }
                    else if (delClaim != "n")
                    {
                        Console.WriteLine("Invalid input");
                    }
                    else
                    {
                        Console.WriteLine("Claim not processed.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are currently no claims to process.");
            }
            Console.ReadLine();
        }

        public void AddNewClaim()
        {
            ClaimType claimType = ClaimType.Car;
            string outPut = null;
            while (true)
            {
                Console.Clear();
                Console.Write($"{outPut}" +
                    $"Enter the type of claim being made." +
                    $"\n1. Car \n2. Home \n3. Theft \n   ");

                string inType = Console.ReadLine();
                if (inType == "1")
                {
                    claimType = ClaimType.Car;
                    break;
                }
                else if (inType == "2")
                {
                    claimType = ClaimType.Home;
                    break;
                }
                else if (inType == "3")
                {
                    claimType = ClaimType.Theft;
                    break;
                }
                else
                {
                    outPut = "Invalid Input, please try again.\n";
                }
            }

            Console.Clear();
            Console.Write("Enter the claim amount: $");
            string claimAmountAsString = Console.ReadLine();
            decimal amount = Decimal.Parse(claimAmountAsString);

            Console.Write("\nEnter a brief description for the claim: ");
            string desc = Console.ReadLine();

            DateTime claimDate = CreateDate("\nEnter the Month, Day, and Year of the claim.");
            DateTime incidentDate = CreateDate("\nEnter the Month, Day, and Year of the incident.");

            _claimRepo.AddNewClaim(type, desc, amount, incidentDate, claimDate);
        }
    }


    private void SeeAllClaims()
    {
        throw new NotImplementedException();
    }
} 

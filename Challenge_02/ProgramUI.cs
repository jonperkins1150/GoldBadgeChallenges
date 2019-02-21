using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    class ProgramUI
    {
        public ClaimRepository _claimRepo = new ClaimRepository();
        int _response;
        public static DateTime CreateDate(string prompt)
        {
            Console.WriteLine($"{prompt} (MM/DD/YYYY)");
            string newDateString = Console.ReadLine();
            DateTime newDate = DateTime.Parse(newDateString);
            return newDate;
        }
        public void Run()
        {
            StartMenu();
        }
        public void StartMenu()
        {       
            while (_response != 4)
            {
                PrintMenu();              
                switch (_response)
                {
                    case 1:
                        ShowAllClaims();
                        break;
                    case 2:
                        ProcessNextClaim();
                        break;
                    case 3:
                        AddClaim();
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
            Console.WriteLine($"Which action would you like to take?\n" +
                    "1. View all claims\n" +
                    "2. Process next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Exit.");
            string responseStr = Console.ReadLine();
            _response = int.Parse(responseStr);
        }
        public void ShowAllClaims()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();
            Console.Clear();
            Console.WriteLine("Claim ID  Claim Type\t Amount\t Date Of Incident\tDate Of Claim\t Is Valid\t Description\n");
            foreach (Claim claim in claimQueue)
            {
                Console.WriteLine($"{ claim.ClaimID}\t\t{ claim.ClaimType}\t ${claim.ClaimAmount} \t{claim.DateOfIncident.ToShortDateString()}        {claim.DateOfClaim.ToShortDateString()} \t{claim.IsValid}\t\t{claim.ClaimDescription}");
            }
            Console.ReadLine();
        }
        public void ProcessNextClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();
            Console.Clear();
            if (claimQueue.Count != 0)
            {
                Claim firstClaim = claimQueue.Peek();
                Console.WriteLine("Below are the details for the next claim to be Processed\n\n");
                Console.WriteLine("Claim ID  Claim Type\t Amount\t Date Of Incident\tDate Of Claim\t Is Valid\t Description\n");
                Console.WriteLine($"{ firstClaim.ClaimID}\t\t{ firstClaim.ClaimType}\t ${firstClaim.ClaimAmount} \t{firstClaim.DateOfIncident.ToShortDateString()}        {firstClaim.DateOfClaim.ToShortDateString()} \t{firstClaim.IsValid}\t\t{firstClaim.ClaimDescription}");
                while (true)
                {
                    Console.Write("Do you want to process this claim now? (y/n): ");
                    string processClaim = Console.ReadLine();
                    if (processClaim == "y")
                    {
                        claimQueue.Dequeue();
                        foreach (Claim claim in claimQueue)
                        {
                            claim.ClaimID = claim.ClaimID -1;
                        }
                        _claimRepo.CountDown();
                        Console.WriteLine("Claim has been processed.");
                        break;
                    }
                    else if (processClaim != "n")
                    {
                        Console.WriteLine("Please make a valid Selection");
                    }
                    else
                    {
                        Console.WriteLine("Claim has not been processed.");
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
        public void AddClaim()
        {
            ClaimType claimType = ClaimType.Car;
            string clmType = null;
            while (true)
            {
                Console.Clear();
                Console.Write($"{clmType}" +
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
                    clmType = "Invalid Selection, please try again.\n";
                }
            }
            Console.Clear();
            Console.Write("Enter the claim amount: $");
            string claimAmtAsStr = Console.ReadLine();
            decimal claimAmount = Convert.ToDecimal(claimAmtAsStr);
            Console.Write("\nEnter a description for the claim: ");
            string claimDescription = Console.ReadLine();
            DateTime incidentDate = CreateDate("\nEnter the Month, Day, and Year of the incident.");
            DateTime claimDate = CreateDate("\nEnter the Month, Day, and Year of the claim.");
            _claimRepo.AddClaim(claimType, claimDescription, claimAmount, incidentDate, claimDate);
        }
    }
}

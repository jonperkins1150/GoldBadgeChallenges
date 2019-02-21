using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    public enum ClaimType
    {
        Car, Home, Theft
    }

    public class Claim
    {
        public Claim(int claimId, ClaimType claimType, string claimDescription, decimal claimAmount, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
            IsValid = isValid;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }
}

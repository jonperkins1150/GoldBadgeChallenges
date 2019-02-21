using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public int claimCount = 0;

        public void AddClaim(ClaimType type, string claimDescription, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            claimCount = claimCount + 1;

            bool valid = false;
            if (((claimDate - incidentDate).TotalDays) < 30)
                valid = true;

            Claim newClaim = new Claim(claimCount, type, claimDescription, claimAmount, incidentDate, claimDate, valid);
            _claimQueue.Enqueue(newClaim);
        }

        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }

        public void CountDown()
        {
            claimCount = claimCount -1;
        } 
    }
}

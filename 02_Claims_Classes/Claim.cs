using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Classes
{
    public enum EClaimType
    {
        Car,
        Home,
        Theft
    }

    public class Claim
    {
        private Guid _id = Guid.NewGuid();

        public Guid ClaimID
        {
            get
            {
                return _id;
            }
        }

        public Claim() { }

        public Claim(EClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public EClaimType ClaimType { get; set; }

        public string Description { get; set; }

        public decimal ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid 
        { 
            get
            {
                return CheckDate();
            }
        }

        public bool CheckDate()
        {
            if ((DateOfClaim - DateOfIncident).TotalDays <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

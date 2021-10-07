using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Classes
{
    public class ClaimRepository
    {
        protected readonly Queue<Claim> _claimDirectory = new Queue<Claim>();

        public bool CreateClaim (Claim claim)
        {
            int startingCount = _claimDirectory.Count;

            _claimDirectory.Enqueue(claim);

            return (_claimDirectory.Count == startingCount + 1);
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _claimDirectory;
        }
    }
}

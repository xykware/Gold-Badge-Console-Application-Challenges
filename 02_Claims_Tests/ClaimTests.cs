using _02_Claims_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimTests
    {
        [TestMethod]
        public void CreateClaim_ShouldReturnCorrectBoolValue()
        {
            ClaimRepository claimRepo = new ClaimRepository();

            DateTime claim1_IncidentDate = new DateTime(2020, 2, 6);
            DateTime claim1_ClaimDate = new DateTime(2020, 2, 12);

            Claim claim1 = new Claim(EClaimType.Car, "Truck got smashed", 6400m, claim1_IncidentDate, claim1_ClaimDate);

            bool actual = claimRepo.CreateClaim(claim1);
            Assert.IsTrue(actual);
        }
    }
}

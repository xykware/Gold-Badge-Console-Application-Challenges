using _03_Badges_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void CreateBadge_()
        {
            BadgeRepository repo = new BadgeRepository();

            List<EDoor> doors = new List<EDoor>();

            doors.Add(EDoor.A1);

            Badge badge = repo.CreateBadge(doors);

            Assert.AreEqual(doors, badge.DoorAccessList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Classes
{
    public enum EDoor
    {
        A1,
        A2,
        A3,
        B1,
        B2,
        B3
    }

    public class Badge
    {
        private Guid _id = Guid.NewGuid();

        public Badge() { }

        public Badge(List<EDoor> doorAccessList)
        {
            DoorAccessList = doorAccessList;
        }

        public Guid BadgeID 
        { 
            get
            {
                return _id;
            }
        }

        public List<EDoor> DoorAccessList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Classes
{
    public class OutingRepository
    {
        private List<Outing> _outingDirectory = new List<Outing>();

        public void AddOuting(Outing outing)
        {
            _outingDirectory.Add(outing);
        }

        public List<Outing> GetAllOutings()
        {
            return _outingDirectory;
        }

        public List<Outing> GetOutingByType(EEventType eventType)
        {
            List<Outing> outingList = new List<Outing>();

            foreach(Outing outing in _outingDirectory)
            {
                if (outing.EventType == eventType)
                {
                    outingList.Add(outing);
                }
            }

            return outingList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Classes
{
    public class BadgeRepository
    {
        private Dictionary<Guid, List<EDoor>> _badgeDictionary = new Dictionary<Guid, List<EDoor>>();

        public Badge CreateBadge (List<EDoor> doorList)
        {
            Badge newBadge = new Badge(doorList);

            _badgeDictionary.Add(newBadge.BadgeID, newBadge.DoorAccessList);

            return newBadge;
        }

        public Dictionary<Guid, List<EDoor>> GetDictionary()
        {
            return _badgeDictionary;
        }

        public void UpdateDictionary(KeyValuePair<Guid, List<EDoor>> kvp)
        {
            _badgeDictionary.Remove(kvp.Key);
            _badgeDictionary.Add(kvp.Key, kvp.Value);
        }
    }
}

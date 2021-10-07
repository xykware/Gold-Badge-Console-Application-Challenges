using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Classes
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();

        public bool CreateMenuItem (Menu menuItem)
        {
            int startingCount = _menuDirectory.Count;

            menuItem.Number = _menuDirectory.Count + 1;
            _menuDirectory.Add(menuItem);
            
            return (_menuDirectory.Count == startingCount + 1);
        }

        public List<Menu> GetMenuItemList ()
        {
            return _menuDirectory;
        }

        public Menu GetMenuItemOfNumber(int itemNumber)
        {
            foreach (Menu menuItem in _menuDirectory)
            {
                if (menuItem.Number == itemNumber)
                {
                    return menuItem;
                }
            }

            return null;
        }

        public bool DeleteMenuItem (Menu menuItem)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Remove(menuItem);

            int i = 1;

            foreach (Menu item in _menuDirectory)
            {
                item.Number = i;
                i++;
            }

            return (_menuDirectory.Count == startingCount - 1);
        }
    }
}

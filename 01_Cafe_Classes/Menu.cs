using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Classes
{
    public class Menu
    {
        public List<string> _ingredients = new List<string>();

        public Menu() { }

        public Menu(string name, string description, List<string> ingredients, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            _ingredients = ingredients;
        }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}

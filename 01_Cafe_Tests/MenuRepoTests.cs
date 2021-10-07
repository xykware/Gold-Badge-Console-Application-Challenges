using _01_Cafe_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepoTests
    {
        [TestMethod]
        public void CreateMenuItem_ShouldReturnCorrectBool()
        {
            List<string> ingredients = new List<string> { "Pepperoni", "Cheddar Cheese", "Cheese Sauce", "Pretzel Crust", "Salt" };

            Menu menuItem = new Menu("Pretzel Pizza", "Cheesy pretzel goodness!", ingredients, 8.97m);
            MenuRepository menuRepo = new MenuRepository();

            bool actual = menuRepo.CreateMenuItem(menuItem);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnCorrectBool()
        {
            List<string> ingredients = new List<string> { "Pepperoni", "Cheddar Cheese", "Cheese Sauce", "Pretzel Crust", "Salt" };

            Menu menuItem = new Menu("Pretzel Pizza", "Cheesy pretzel goodness!", ingredients, 8.97m);
            MenuRepository menuRepo = new MenuRepository();

            menuRepo.CreateMenuItem(menuItem);

            bool actual = menuRepo.DeleteMenuItem(menuItem);

            Assert.IsTrue(actual);
        }
    }
}

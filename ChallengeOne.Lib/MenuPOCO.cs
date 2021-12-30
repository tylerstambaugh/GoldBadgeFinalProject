using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Lib
{
    public class MenuItem
    {
        //A meal number, so customers can say "I'll have the #5"
        //A meal name
        //A description
        //A list of ingredients,
        //A price

        //properties and constructors for menu object.

        private int MenuID { get; set; }
        public int MenuNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; }
        public decimal MealPrice { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int menunumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice)
        {
            MenuID++;
            MenuNumber = menunumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}

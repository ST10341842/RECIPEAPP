using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RECIPEAPP
{
    internal class RecipeBase
    {
        // Encapsulated fields
        private string dishName;
        private List<string> ingredients;
        private List<double> quantities;
        private List<string> units;
        private List<string> steps;
        private List<double> calories;//add calolries 
        private List<string> foodGroups; // add food group 

        // Property for dishName
        public string DishName
        {
            get { return dishName; }
            set { dishName = value; }
        }
        // Constructor
        public RecipeBase()
        {
            dishName = string.Empty;
            ingredients = new List<string>();
            quantities = new List<double>();
            units = new List<string>();
            steps = new List<string>();
        }
        // Properties for encapsulation
        public List<string> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        public List<double> Quantities
        {
            get { return quantities; }
            set { quantities = value; }
        }
        public List<string> Units
        {
            get { return units; }
            set { units = value; }
        }
        public List<string> Steps
        {
            get { return steps; }
            set { steps = value; }
        }
        public List<double> Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public List<string> FoodGroups
        {
            get { return foodGroups; }
            set { foodGroups = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RECIPEAPP
{
    internal class Recipe : RecipeBase
    {

        public Recipe() : base()
        {
            Calories = new List<double>();
            originalQuantities = new List<double>();
            FoodGroups = new List<string>();
        }

        // Delegate to notify the user
        public delegate void CaloriesExceededHandler(string message);

        // Event to trigger the notification
        public event CaloriesExceededHandler CaloriesExceeded;

        //Field to store the original quantities before scaling
        private List<double> originalQuantities;

        // Method for entering recipe details via user input
        public void EnterDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            Ingredients.Clear();
            Quantities.Clear();
            Units.Clear();
            Calories.Clear(); // calories for each ingredient
            FoodGroups.Clear(); // food group for each ingredient 

            // Define the food groups
            List<string> foodGroups = new List<string>
    {
        "Starchy foods",
        "Vegetables and fruits",
        "Dry beans, peas, lentils and soya",
        "Chicken, fish, meat and eggs",
        "Milk and dairy products",
        "Fats and oil",
        "Water"
    };

            // Loop to input each ingredient's details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                Ingredients.Add(Console.ReadLine());

                Console.WriteLine($"Enter quantity for {Ingredients[i]}:");
                Quantities.Add(double.Parse(Console.ReadLine()));

                Console.WriteLine($"Enter unit for {Ingredients[i]}:");
                Units.Add(Console.ReadLine());

                Console.WriteLine($"Enter calories for {Ingredients[i]}:"); // New: Prompt for calories
                Calories.Add(double.Parse(Console.ReadLine()));

                // Prompt for food group and inform about available options
                Console.WriteLine($"Select the food group for {Ingredients[i]} by entering the corresponding number:");
                for (int j = 0; j < foodGroups.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {foodGroups[j]}");
                }
                int foodGroupChoice;
                bool validChoice;
                do
                {
                    Console.Write("Enter your choice: ");
                    validChoice = int.TryParse(Console.ReadLine(), out foodGroupChoice);
                    if (!validChoice || foodGroupChoice < 1 || foodGroupChoice > foodGroups.Count)
                    {
                        Console.WriteLine("Invalid choice. Please enter a number corresponding to the food group.");
                    }
                } while (!validChoice || foodGroupChoice < 1 || foodGroupChoice > foodGroups.Count);

                // Ensure FoodGroups list has enough elements
                while (FoodGroups.Count <= i)
                {
                    FoodGroups.Add("");
                }

                // Assign food group to ingredient
                FoodGroups[i] = foodGroups[foodGroupChoice - 1];
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            Steps.Clear();

            // Loop to input each cooking step
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                Steps.Add(Console.ReadLine());
            }
        }
        // Method to display the complete recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe for {DishName}:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{Quantities[i]} {Units[i]} of {Ingredients[i]} - {Calories[i]} calories, Food Group: {FoodGroups[i]}"); //new change
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.WriteLine($"Total Calories: {CalculateTotalCalories()}"); // New: Display total calories
        }
        private double CalculateTotalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                totalCalories += Quantities[i] * Calories[i];
            }
            return totalCalories;

        }

        // Method to scale the quantities of the ingredients
        public void ScaleRecipe(double factor)
        {
            if (originalQuantities == null)
            {
                originalQuantities = new List<double>(Quantities);
            }
            // Adjust each quantity by the scaling factor
            for (int i = 0; i < Quantities.Count; i++)
            {
                Quantities[i] = originalQuantities[i] * factor;
            }
        }
        // Method to reset quantities to their original values
        public void ResetQuantities()
        {
            if (originalQuantities != null)
            {
                Quantities = new List<double>(originalQuantities);
            }
        }
        // method to clear all recipe data to their origunal value
        public void ClearRecipeData()
        {
            DishName = string.Empty;
            Ingredients.Clear();
            Quantities.Clear();
            Units.Clear();
            Steps.Clear();
            Console.WriteLine("All recipe data has been cleared.");
        }
        //check if the total calories exceed 300 and notify the user
        public void CheckCalories()
        {
            double totalCalories = CalculateTotalCalories();
            if (totalCalories > 0)
            {
                //notify the user through the delegate
                CaloriesExceeded?.Invoke($"Warning: Total calories ({totalCalories}) exceed 300!");
            }
        }
    }
}

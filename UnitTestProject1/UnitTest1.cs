using Microsoft.VisualStudio.TestTools.UnitTesting;
using RECIPEAPP;
using System.Collections.Generic;

namespace RECIPEAPP.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CalculateTotalCalories_ShouldReturnCorrectValue()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients = new List<string> { "Ingredient1", "Ingredient2" };
            recipe.Quantities = new List<double> { 100, 200 };
            recipe.Calories = new List<double> { 10, 20 };

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(5000, totalCalories); // Replace 5000 with the expected total calories value
        }
    }
}

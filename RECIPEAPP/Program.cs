namespace RECIPEAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
    "*******************************************************   **************************************************************" + "\n" +
    "                                                   Welcome To One Stop Recipe" + "\n" +
    "*********************************************************************************************************************");
            RecipeManager manager = new RecipeManager();
            manager.MainMenu(); // call the main menu method to start the application's main loop
        }
    }
}

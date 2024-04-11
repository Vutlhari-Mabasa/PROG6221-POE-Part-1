using System;

namespace RecipeApp
{
    // Ingredient class to represent each ingredient
    public class Ingredient
    {
        // Properties to store ingredient details
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public double OriginalQuantity { get; }

        // Constructor to initialize ingredient details
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            OriginalQuantity = quantity;
        }
    }

    // Recipe class to manage recipe details
    public class Recipe
    {
        // Properties to store recipe details
        public string Name { get; }
        private Ingredient[] ingredients;
        private string[] steps;

        // Constructor to initialize recipe details
        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            ingredients = new Ingredient[numIngredients];
            steps = new string[numSteps];
        }

        // Method to add ingredients to the recipe
        public void AddIngredient(int index, Ingredient ingredient)
        {
            ingredients[index] = ingredient;
        }

        // Method to add steps to the recipe
        public void AddStep(int index, string step)
        {
            steps[index] = step;
        }

        // Method to display recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine($"Recipe Name: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.WriteLine("**************************************************************************");
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        // Method to clear recipe data
        public void ClearData()
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = null;

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear data");
                Console.WriteLine("6. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe = EnterRecipeDetails();
                        break;
                    case 2:
                        if (recipe != null)
                            recipe.DisplayRecipe();
                        else
                            Console.WriteLine("No recipe details entered yet.");
                        break;
                    case 3:
                        if (recipe != null)
                            ScaleRecipe(recipe);
                        else
                            Console.WriteLine("No recipe details entered yet.");
                        break;
                    case 4:
                        if (recipe != null)
                            recipe.ResetQuantities();
                        else
                            Console.WriteLine("No recipe details entered yet.");
                        break;
                    case 5:
                        recipe = null;
                        Console.WriteLine("Recipe data cleared.");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        static Recipe EnterRecipeDetails()
        {
            // Prompt user to enter recipe name
            Console.WriteLine("Enter recipe name:");
            string recipeName = Console.ReadLine();

            // Prompt user to enter number of ingredients
            Console.WriteLine("Enter amount of ingredients:");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            // Prompt user to enter number of steps
            Console.WriteLine("Enter number of steps:");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            // Create a new recipe object
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);

            // Prompt user to enter ingredient details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();

                // Create an Ingredient object and add it to the recipe
                Ingredient ingredient = new Ingredient(name, quantity, unit);
                recipe.AddIngredient(i, ingredient);
            }

            // Prompt user to enter step details
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                // Add step description to the recipe
                recipe.AddStep(i, description);
            }

            return recipe;
        }

        static void ScaleRecipe(Recipe recipe)
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("Enter scaling factor (0.5, 2, or 3): ");
            double scalingFactor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(scalingFactor);

            // Display scaled recipe
            Console.WriteLine("\nScaled Recipe:");
            recipe.DisplayRecipe();
            Console.WriteLine("**************************************************************************");
        }
    }
}

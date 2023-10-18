using RestSharpCGet.API;
using RestSharpCGet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpCGet 
{
	internal class UserInterface
	{
		private DrinksController _controller;

		private DrinksService drinksService = new();

		DrinksApiAccess _apiClient;

		public UserInterface(DrinksController controller)
		{
			_controller = controller;
		}

		public async Task Run()
		{
			List<string> categories = (await _controller.GetCategories()).ToList();

			while (true)
			{
				Console.Clear();
				foreach (string category in categories)
				{
					Console.WriteLine(category);
				}

				Console.WriteLine("\nPlease enter your choice: ");

				string drink = Console.ReadLine();

				if (drink.ToLower() == "exit")
				{
					return;
				}

				await ShowDrinksMenu(drink);
			}
		}

		public async Task ShowDrinksMenu(string choice)
		{
			List<Drink> drinks = (await _controller.GetDrinksByCategory(choice)).ToList();

			while (true)
			{
				Console.Clear();

				foreach (var drink in drinks)
				{
					Console.WriteLine($"{drink.Id} -- {drink.Name}");
				}

				Console.WriteLine("\nPlease enter ID of your drink choice: ");

				string detailChoice = Console.ReadLine();

				await ShowDrinkDetail(Int32.Parse(detailChoice));
				break;
			}
		}

		public async Task ShowDrinkDetail(int choice)
		{
			//drinksService.GetDrinkDetail(choice);
			DrinkDetailsDto selectedDrink = (await _controller.GetDrinkDetail(choice));

			Console.Clear();
			//var drinks = _apiClient.GetDrinkDetail(choice);
			Console.WriteLine($"{selectedDrink.Name}\n");
			Console.WriteLine($"Drink Category:  {selectedDrink.Category}");
			Console.WriteLine($"\nGlass:  {selectedDrink.Glass}");

			var instructionsTable = new Table();

			instructionsTable.Title($"Instructions:  {selectedDrink.Instructions}");
			instructionsTable.AddColumn(new TableColumn("Ingredients").Centered());
			instructionsTable.AddColumn(new TableColumn("Measurements").Centered());
			instructionsTable.Expand();

			foreach (var ingredient in selectedDrink.Ingredients)
			{
				var ingredientName = ingredient.Name;
				var measurement = ingredient.Measure;

				instructionsTable.AddRow(ingredientName, measurement);
			}

			var layout = new Panel(new Rows(
			instructionsTable
			));
			layout.Expand();

			AnsiConsole.Write(layout);

			Console.WriteLine("\nPress any key for the main menu...");
			Console.ReadKey();


			//Console.WriteLine($"\n\nInstructions:");
			//Console.WriteLine($"\n{selectedDrink.Instructions}");
			//Console.WriteLine($"\n\nIngredients");

			//foreach (var ingredient in selectedDrink.Ingredients)
			//{
			//	//var ingredientName = ingredient.Name;

			//	Console.WriteLine($"{ingredient.Name}");
			//}

			//Console.WriteLine($"\n\nMeasurements:");

			//foreach (var measurement in selectedDrink.Ingredients)
			//{
			//	Console.WriteLine($"{measurement.Measure}");
			//}





			//if (!drinks.Any(x => x.id))

			//Console.Clear();

			//foreach (var drink in drinkList)
			//{
			//	Console.WriteLine(drink);
			//}

			//var drinkId = drinks.FirstOrDefault(c => c.Name == chosen)
		}
	}
}

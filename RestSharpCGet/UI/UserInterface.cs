using RestSharpCGet.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class UserInterface
{
		private DrinksController _controller;

		public UserInterface(DrinksController controller)
		{
			_controller = controller;
		}

		public async Task Run()
		{
			List<string> categories = (await _controller.GetCategories()).ToList();

			foreach (string category in categories)
			{
				Console.WriteLine(category);
			}

			Console.WriteLine("\nPlease enter your choice: ");

			string drink = Console.ReadLine();

			await ShowDrinksMenu(drink);
		}

		public async Task ShowDrinksMenu(string choice)
		{
			List<Drink> drinks = (await _controller.GetDrinksByCategory(choice)).ToList();

			Console.Clear();

			foreach(var drink in drinks) 
			{
				Console.WriteLine(drink.Name.ToString());
			}

			Console.WriteLine("\nPlease enter your choice: ");

			string detailChoice = Console.ReadLine();

			await ShowDrinksMenu(choice);
	}

		public async Task ShowDrinkDetail(string choice)
		{
			List<Drink> drinks = (await _controller.GetDrinkDetail(choice)).ToList();

			Console.Clear();

			foreach (var drink in drinks)
			{
				Console.WriteLine(drink.Name.ToString());
			}
		}
}

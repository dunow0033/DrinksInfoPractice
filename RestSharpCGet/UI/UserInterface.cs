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
		}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpCGet.API
{
	internal class DrinksApiAccess
	{
		private readonly HttpClient _apiClient;

		public DrinksApiAccess(HttpClient apiClient)
		{
			_apiClient = apiClient;
		}

		public async Task<IEnumerable<Category>> GetCategories()
		{
			var response = await _apiClient.GetFromJsonAsync<CategoryResponse>("list.php?c=list");

			return response.Categories;
		}

		public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
		{
		//	var categoryNameUrlString = category.Replace(" ", "_");
			var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={category}");

			return response.Drinks;
		}

		public async Task<IEnumerable<Drink>> GetDrinkDetail(string drink)
		{
			//	var categoryNameUrlString = category.Replace(" ", "_");
			var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"lookup.php?i={drink}");

			return response.Drinks;
		}
	}
}

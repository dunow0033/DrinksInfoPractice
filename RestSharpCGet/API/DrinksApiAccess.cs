using System.Net.Http.Json;

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
			var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={category}");

			return response.Drinks;
		}

		public async Task<DrinkDetails> GetDrinkDetail(int drink)
		{
			var response = await _apiClient.GetFromJsonAsync<DrinkDetailsResponse>($"lookup.php?i={drink}");

			return response.Drinks.ToList()[0];
		}
	}
}

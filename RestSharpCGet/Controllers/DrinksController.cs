using RestSharpCGet.API;
using System.Text.Json;

internal class DrinksController
{
	private DrinksApiAccess _apiRepo;

	public DrinksController(DrinksApiAccess apiRepo)
	{
		_apiRepo = apiRepo;
	}

	public async Task<IEnumerable<string>> GetCategories()
	{
		var categories = await _apiRepo.GetCategories();

		return categories.Select(categories => categories.Name);
	}

	public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
	{
		var categories = await _apiRepo.GetDrinksByCategory(category);

		return categories;
	}

	public async Task<IEnumerable<Drink>> GetDrinkDetail(string drink)
	{
		var details = await _apiRepo.GetDrinkDetail(drink);

		return details;
	}
}

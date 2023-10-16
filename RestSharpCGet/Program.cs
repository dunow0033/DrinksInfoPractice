using RestSharpCGet;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharpCGet.API;
//using System.Text.Json;

class Program
{

	private static HttpClient apiClient = new()
	{
		BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
	};

	static async Task Main()
	{
		var apiRepo = new DrinksApiAccess(apiClient);
		var controller = new DrinksController(apiRepo);
		var drinksApp = new UserInterface(controller);

		await drinksApp.Run();
	}
}
	

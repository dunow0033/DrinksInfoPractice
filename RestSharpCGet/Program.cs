using RestSharpCGet;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharpCGet.API;
//using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json.Linq;

class Program
{
	//private static string url = "http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";

	//private static HttpClient httpClient = new HttpClient();

	private static HttpClient apiClient = new()
	{
		BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
		//BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list")
	};

	static async Task Main()
	{
		var apiRepo = new DrinksApiAccess(apiClient);
		var controller = new DrinksController(apiRepo);
		var drinksApp = new UserInterface(controller);

		await drinksApp.Run();

		//using (HttpResponseMessage response = await httpClient.GetAsync(url))
		//{

		//if (response.IsSuccessStatusCode)
		//{
		//	string jsonResponse = await response.Content.ReadAsStringAsync();

		//	var drinkData = JObject.Parse(jsonResponse);

		//	foreach (var category in drinkData["drinks"])
		//	{
		//		Console.WriteLine(category);
		//	}
		//var response1 = await httpClient.GetFromJsonAsync<CategoryResponse>

		//}
		//}
	}
}
	

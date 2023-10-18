﻿using Newtonsoft.Json;
using RestSharp;
using RestSharpCGet.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
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

		public async Task<DrinkDetails> GetDrinkDetail(int drink)
		{
			//	var categoryNameUrlString = category.Replace(" ", "_");
			//var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
			//var request = new RestRequest($"lookup.php?i={drink}");
			//var response = client.ExecuteAsync(request);
			var response = await _apiClient.GetFromJsonAsync<DrinkDetailsResponse>($"lookup.php?i={drink}");

			return response.Drinks.ToList()[0];
			//if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
			//{
			//	string rawResponse = response.Result.Content;

			//	var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

			//	List<DrinkDetail> returnedList = serialize.DrinkDetailList;

			//	DrinkDetail drinkDetail = returnedList[0];

			//	List<object> prepList = new();

			//	string formattedName = "";

			//	foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
			//	{

			//		if (prop.Name.Contains("str"))
			//		{
			//			formattedName = prop.Name.Substring(3);
			//		}

			//		if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
			//		{
			//			prepList.Add(new
			//			{
			//				Key = formattedName,
			//				Value = prop.GetValue(drinkDetail)
			//			});
			//		}
			//	}

			//	TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);
			//}
		}
	}
}

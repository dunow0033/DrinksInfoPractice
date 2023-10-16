using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

internal record class Drink(
	[property: JsonPropertyName("idDrink")] int Id,
	[property: JsonPropertyName("strDrink")] string Name);

internal record class DrinkResponse(
	[property: JsonPropertyName("drinks")] IEnumerable<Drink> Drinks);
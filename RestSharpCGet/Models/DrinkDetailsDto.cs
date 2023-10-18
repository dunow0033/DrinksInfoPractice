using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpCGet.Models
{
	internal class DrinkDetailsDto
	{
		public string Name { get; set; }
		public string Alcoholic { get; set; }
		public string Category { get; set; }
		public string Glass { get; set; }
		public string Instructions { get; set; }
		public List<Ingredient> Ingredients { get; set; }
	}
}

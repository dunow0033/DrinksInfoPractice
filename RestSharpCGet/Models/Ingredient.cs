using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpCGet.Models
{
	internal class Ingredient
	{
		public string Name { get; set; }
		public string Measure { get; set; }
		public Ingredient(string name, string measure)
		{
			Name = name;
			Measure = measure;
		}
	}
}

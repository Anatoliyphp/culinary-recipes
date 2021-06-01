using System.Collections.Generic;

namespace recipe_domain
{
	public class Tag
	{
		public int TagId { get; set; }
		public string Name { get; set; }
		public ICollection<Recipe> Recipes { get; set; }
	}
}

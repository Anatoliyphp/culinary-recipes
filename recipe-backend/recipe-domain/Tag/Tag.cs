using Abp.Domain.Entities;
using System.Collections.Generic;

namespace recipe_domain
{
	public class Tag: Entity
	{
		public Tag(string name)
		{
			Name = name;
		}

		public int TagId { get; set; }

		public string Name { get; set; }

		public List<Recipe> Recipes { get; set; }
	}
}

using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace recipe_domain
{
	public class Tag: Entity
	{
		public Tag(string name)
		{
			Name = name;
		}

		public string Name { get; set; }

		public List<RecipeTag> RecipeTags { get; set; }

		public static implicit operator Tag(EntityEntry<Tag> v)
		{
			throw new NotImplementedException();
		}
	}
}

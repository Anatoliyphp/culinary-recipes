using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace recipe_domain
{
	public class RecipeLike: Entity
	{
		public RecipeLike(
				int userId,
				//User user,
				int recipeId
				//Recipe recipe
				)
		{
			UserId = userId;
			//User = user;
			RecipeId = recipeId;
			//Recipe = recipe;
		}

		public int UserId { get; set; }
		public User User { get; set; }

		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
	}
}

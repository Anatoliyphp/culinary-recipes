using recipe_domain;
using System;
using System.Collections.Generic;

namespace Application
{
	public class RecipeValidator : IValidator<Recipe>
	{
		public override IReadOnlyList<Exception> GetExceptions(Recipe recipe)
		{
			List<Exception> exceptions = new List<Exception>();

			if (recipe.Name.Length > 30 || recipe.Name.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Recipe name is invalid"));
			}

			if (recipe.Img.Length > 100)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Recipe image is invalid"));
			}

			if (recipe.Description.Length > 300)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Recipe description is invalid"));
			}

			if (recipe.Time <= 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Recipe time is invalid"));
			}

			if (recipe.Persons <= 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Recipe persons is invalid"));
			}

			return exceptions;
		}
	}
}

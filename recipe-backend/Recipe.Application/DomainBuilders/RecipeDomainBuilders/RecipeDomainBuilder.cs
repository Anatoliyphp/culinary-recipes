using Microsoft.AspNetCore.Http;
using recipe_domain;
using System.IO;

namespace Application
{
	class RecipeDomainBuilder : IRecipeDomainBuilder
	{
		public Recipe CreateRecipe(FullRecipeDto recipeDto)
		{
			if (recipeDto != null)
			{
				Recipe recipe = new Recipe (
					ConvertImageToByteArray(recipeDto.Img),
					recipeDto.Name,
					recipeDto.Desc,
					recipeDto.Time,
					recipeDto.Persons,
					recipeDto.Likes,
					recipeDto.UserId
				);
				recipe.Steps = recipeDto.Steps
					.ConvertAll(s => new Step(s.Name, s.Desc, recipe.Id));
				recipe.Ingridients = recipeDto.Ingridients
					.ConvertAll(i => new Ingridient(i.Name, i.List, recipe.Id));
				recipe.Tags = recipeDto.Tags
					.ConvertAll(t => new Tag(t.Name));

				return recipe;
			}
			return null;
		}

		private byte[] ConvertImageToByteArray(IFormFile img)
		{
			if (img.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					img.CopyTo(ms);
					return ms.ToArray();
				}
			}
			return null;
		}
	}
}

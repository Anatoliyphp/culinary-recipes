using recipe_domain;

namespace Application
{
	class RecipeDomainBuilder : IRecipeDomainBuilder
	{

		public Recipe CreateRecipe(FullRecipeRequestDto recipeDto, string img)
		{
			if (recipeDto != null)
			{
				Recipe recipe = new Recipe (
					img,
					recipeDto.Name,
					recipeDto.Description,
					recipeDto.Time,
					recipeDto.Persons,
					recipeDto.UserId
				);
				recipe.Steps = recipeDto.Steps
					.ConvertAll(s => new Step(s.Name, s.Desc, recipe.Id));
				recipe.Ingridients = recipeDto.Ingridients
					.ConvertAll(i => new Ingridient(i.Name, i.List, recipe.Id));

				return recipe;
			}
			return null;
		}
	}
}

using Application;
using recipe_domain;

namespace recipe_api.Recipes.Builders
{
	public class RecipeUpdateBuilder
	{
		public void UpdateRecipe(Recipe recipe, FullRecipeRequestDto requestDto, string imgPath)
		{
			recipe.Description = requestDto.Description;
			if (imgPath != null)
			{
				recipe.Img = imgPath;
			}
			recipe.Name = requestDto.Name;
			recipe.Time = requestDto.Time;
			recipe.Persons = requestDto.Persons;
			recipe.Ingridients = requestDto.Ingridients.ConvertAll(i => new Ingridient(i.Name, i.List, recipe.Id));
			recipe.Steps = requestDto.Steps.ConvertAll(s => new Step(s.Name, s.Desc, recipe.Id));

		}
	}
}

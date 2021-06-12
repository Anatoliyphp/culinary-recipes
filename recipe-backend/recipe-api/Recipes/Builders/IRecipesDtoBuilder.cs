using Application;
using recipe_domain;
using System.Threading.Tasks;

namespace recipe_api
{
	public interface IRecipesDtoBuilder
	{
		RecipeDto CreateRecipeDto(Recipe recipe);

		Task<FullRecipeDto> CreateFullRecipeDto(int recipeId);
	}
}

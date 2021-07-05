using Application;
using recipe_domain;
using System.Threading.Tasks;

namespace recipe_api
{
	public interface IRecipesDtoBuilder
	{
		Task<RecipeDto> CreateRecipeDto(Recipe recipe, int userId);

		Task<FullRecipeResponseDto> CreateFullRecipeDto(int recipeId, int userId);

		Task<BestRecipeDto> CreateBestRecipe(Recipe recipe);
	}
}

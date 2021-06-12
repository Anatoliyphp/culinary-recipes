using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IRecipeRepository
	{
		Task<Recipe> GetBestRecipe();

		Task<List<Recipe>> GetAllRecipes();

		Task<List<Recipe>> GetAllFavouritesRecipes(int userId);

		Task<List<Recipe>> GetAllUsersRecipes(int userId);

		Task<Recipe> GetRecipeById(int recipeId);

		Recipe[] GetAllRecipesByName(string name);

		Task AddRecipe(Recipe recipe);

		Task<bool> DeleteRecipe(int id);

		Task ChangeRecipe(Recipe recipe);

		void Like(Recipe recipe);

	}
}

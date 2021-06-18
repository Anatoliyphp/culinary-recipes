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

		Task<List<Recipe>> GetAllRecipesByName(string name);

		Task AddRecipe(Recipe recipe);

		Task<bool> DeleteRecipe(int id);

		void ChangeRecipe(Recipe recipe);

		Task<bool> Like(int userId, int recipreId);

		Task<bool> IsLikedForCurrentUser(int userID, int recipeId);

		Task<bool> IsFavouriteForCurrentUser(int userId, int recipeId);

		Task<bool> DeleteFromFavourites(int userID, int recipeId);

		Task<int> GetFavouritesNumber(int recipeId);

		Task<int> GetLikesNumber(int recipeId);

		Task<bool> RemoveLike(int userId, int recipeId);

		Task<List<Recipe>> GetAllByTags(string[] tagNames);

		Task<bool> AddToFavourites(int userId, int recipeId);

		Task<bool> IsRepeatingImage(string path);

	}
}

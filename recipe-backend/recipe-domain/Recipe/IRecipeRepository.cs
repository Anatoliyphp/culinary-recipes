using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IRecipeRepository
	{
		Task<Recipe> GetBestRecipe();

		Task<List<Tag>> GetAllTags();

		Task<List<Recipe>> GetAllRecipes();

		Task AddRecipeTags(int recipeId, List<string> TagNames);

		int GetUserFavouritesNumber(List<Recipe> recipes);

		int GetUserLikesNumber(List<Recipe> recipes);

		Task<List<Recipe>> GetAllFavouritesRecipes(int userId);

		Task<List<Recipe>> GetAllUsersRecipes(int userId);

		Task<Recipe> GetRecipeById(int recipeId);

		Task AddRecipe(Recipe recipe);

		Task<bool> DeleteRecipe(int id);

		void ChangeRecipe(Recipe recipe);

		Task AddTags(List<string> TagNames);

		Task<bool> IsLikedForCurrentUser(int userID, int recipeId);

		Task<bool> IsFavouriteForCurrentUser(int userId, int recipeId);

		Task<bool> DeleteFromFavourites(int userID, int recipeId);

		Task<int> GetFavouritesNumber(int recipeId);

		Task<int> GetLikesNumber(int recipeId);

		Task<bool> RemoveLike(int userId, int recipeId);

		Task<List<Recipe>> SearchRecipes(int[] tagIds, string name);

		Task<bool> IsRepeatingImage(string path);

		Task<List<Tag>> GetRecipeTags(int recipeId);

	}
}

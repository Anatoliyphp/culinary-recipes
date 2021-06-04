using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IRecipeRepository
	{
		Recipe GetBestRecipe();

		Task<List<Recipe>> GetAllRecipes();

		List<Recipe> GetAllFavouritesRecipes(User user);

		Task<List<Recipe>> GetAllUsersRecipes(User user);

		Recipe[] GetAllRecipesByName(string name);

		void AddRecipe(Recipe recipe);

		void DeleteRecipe(Recipe recipe);

		void ChangeRecipe(Recipe recipe);

		void Like(Recipe recipe);

		void AddStep(int recipeId, Step step);//change | delete

		void AddTag(int recipeId, Tag tag);//change | delete

		void AddIngridient(int recipeId, Ingridient ingridient);//change | delete

	}
}

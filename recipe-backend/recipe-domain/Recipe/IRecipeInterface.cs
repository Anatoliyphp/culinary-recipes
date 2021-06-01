namespace recipe_domain
{
	interface IRecipeInterface
	{
		Recipe GetBestRecipe();
		Recipe[] GetAllFavouritesRecipes(User user);
		Recipe[] GetAllUsersRecipes(User user);
		Recipe[] GetAllRecipesByName(string name);
	}
}

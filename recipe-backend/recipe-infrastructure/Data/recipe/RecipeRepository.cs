using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using recipe_domain;

namespace recipe_infrastructure
{
	public class RecipeRepository: IRecipeRepository
	{
		private RecipesContext db;

		public RecipeRepository(RecipesContext context)
		{
			db = context;
		}

		public Recipe GetBestRecipe()
		{
			IQueryable<Recipe> recipes = db.Recipes;
			recipes = recipes.OrderBy(r => r.Likes);
			return recipes.First();
		}

		public async Task<List<Recipe>> GetAllRecipes()
		{
			IQueryable<Recipe> recipes = db.Recipes;
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
		}

		public async Task<List<Recipe>> GetAllUsersRecipes(User user)
		{
			IQueryable<Recipe> recipes = db.Recipes.Where(r => r.UserId == user.UserId);
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
		}

		public List<Recipe> GetAllFavouritesRecipes(User user)
		{
			List<Recipe> recipes = user.GetRecipes();
			return (List<Recipe>)recipes.OrderBy(r => r.Likes);
		}

		public Recipe[] GetAllRecipesByName(string name)//TODO
		{
			return new Recipe[0];
		}

		public async void AddRecipe(Recipe recipe)//TODO
		{
			db.Recipes.Add(recipe);
			await db.SaveChangesAsync();
		}

		public async void DeleteRecipe(Recipe recipe)//TODO
		{
			db.Recipes.Remove(recipe);
			await db.SaveChangesAsync();
		}

		public async void ChangeRecipe(Recipe recipe)//TODO
		{
			db.Recipes.Update(recipe);
			await db.SaveChangesAsync();
		}

		public void Like(Recipe recipe)
		{
		}

		public void AddStep(int recipeId, Step step)
		{
		}

		public void AddTag(int recipeId, Tag tag)
		{
		}

		public void AddIngridient(int recipeId, Ingridient ingridient)
		{
		}
	}
}

using System;
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

		public async Task<Recipe> GetBestRecipe()
		{
			IQueryable<Recipe> recipes = db.Recipes.OrderBy(r => r.Likes);
			return await recipes.FirstAsync();
		}

		public async Task<List<Recipe>> GetAllRecipes()
		{
			IQueryable<Recipe> recipes = db.Recipes;
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
		}

		public async Task<List<Recipe>> GetAllUsersRecipes(int userId)
		{
			IQueryable<Recipe> recipes = db.Recipes.Where(r => r.UserId == userId);
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
		}

		public async Task<List<Recipe>> GetAllFavouritesRecipes(int userId)
		{
			User user = await db.Users
				.Where(u => u.Id == userId)
				.Include(u => u.UserFavourites)
				.SingleOrDefaultAsync();
			//if (user != null)
			//{
			//	return user.UserFavourites.ToList();
			//}
			return null;
		}

		public Recipe[] GetAllRecipesByName(string name)//TODO
		{
			return new Recipe[0];
		}

		public async Task AddRecipe(Recipe recipe)
		{
			db.Recipes.Add(recipe);
			await db.SaveChangesAsync();
		}

		public async Task<bool> DeleteRecipe(int id)
		{
			Recipe recipe = await db.Recipes.SingleOrDefaultAsync(r => r.Id == id);
			if (recipe != null)
			{
				db.Recipes.Remove(recipe);
				await db.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task ChangeRecipe(Recipe recipe)
		{
			db.Recipes.Update(recipe);
			await db.SaveChangesAsync();
		}

		public void Like(Recipe recipe)
		{
		}

		public async Task<Recipe> GetRecipeById(int recipeId)
		{
			return await db.Recipes.SingleOrDefaultAsync(r => r.Id == recipeId);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using recipe_domain;

namespace recipe_infrastructure
{
	public class RecipeRepository : IRecipeRepository
	{
		private RecipesContext db;

		public RecipeRepository(RecipesContext context)
		{
			db = context;
		}

		public async Task<Recipe> GetBestRecipe()
		{
			List<Recipe> recipes = await GetAllRecipes();
			Recipe bestRecipe = recipes.FirstOrDefault();
			foreach (Recipe recipe in recipes)
			{
				if ( await GetLikesNumber(recipe.Id) > await GetLikesNumber(bestRecipe.Id))
				{
					bestRecipe = recipe;
				}
			}

			return bestRecipe;
		}

		public async Task<List<Recipe>> GetAllRecipes()
		{
			IQueryable<Recipe> recipes = db.Recipes;
			return await recipes.ToListAsync();
		}

		public async Task<List<Recipe>> GetAllUsersRecipes(int userId)
		{
			IQueryable<Recipe> recipes = db.Recipes
				.Where(r => r.UserId == userId);
			return await recipes.ToListAsync();
		}

		public async Task<List<Recipe>> GetAllFavouritesRecipes(int userId)
		{
			List<UserFavourites> userFavourites = await db.UserFavourites
				.Include(uf => uf.Recipe)
				.Where(uf => uf.UserId == userId)
				.ToListAsync();

			if (userFavourites != null)
			{
				return userFavourites.ConvertAll(r => r.Recipe);
			}
			return null;
		}

		public async Task<List<Recipe>> GetAllRecipesByName(string name)
		{
			return await db.Recipes
				.Where(r => EF.Functions.Like(r.Name, name))
				.ToListAsync();
		}

		public async Task AddRecipe(Recipe recipe)
		{
			await db.Recipes.AddAsync(recipe);
		}

		public async Task<bool> DeleteRecipe(int id)
		{
			Recipe recipe = await db.Recipes.SingleOrDefaultAsync(r => r.Id == id);
			if (recipe != null)
			{
				db.Recipes.Remove(recipe);
				return true;
			}
			return false;
		}

		public void ChangeRecipe(Recipe recipe)
		{
			db.Recipes.Update(recipe);
		}

		public async Task<bool> Like(int userId, int recipeId)
		{
			Recipe recipe = await db.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
			User user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (recipe != null && user != null)
			{
				RecipeLike recipeLike = new RecipeLike(
					userId,
					recipeId
				);
				await db.RecipeLikes.AddAsync(recipeLike);

				return true;
			}

			return false;
		}

		public async Task<Recipe> GetRecipeById(int recipeId)
		{
			return await db.Recipes
				.Include(r => r.Steps)
				.Include(r => r.Ingridients)
				.SingleOrDefaultAsync(r => r.Id == recipeId);
		}

		public Task<List<Recipe>> GetAllByTags(string[] tagNames)//int where id in ()
		{
			//in one
			throw new System.NotImplementedException();
		}

		public async Task<bool> AddToFavourites(int userId, int recipeId)
		{
			Recipe recipe = await db.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
			User user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (recipe != null && user != null)
			{
				UserFavourites userFavourites = new UserFavourites(
					userId,
					recipeId
				);
				await db.UserFavourites.AddAsync(userFavourites);

				return true;
			}

			return false;
		}

		public async Task<bool> DeleteFromFavourites(int userID, int recipeId)
		{
			UserFavourites userFavourites = await db.UserFavourites
				.FirstOrDefaultAsync(uf => uf.RecipeId == recipeId && uf.UserId == userID);
			if (userFavourites != null)
			{
				db.UserFavourites.Remove(userFavourites);
				return true;
			}

			return false;
		}

		public async Task<int> GetFavouritesNumber(int recipeId)
		{
			return await db.UserFavourites.CountAsync(uf => uf.RecipeId == recipeId);
		}

		public async Task<bool> IsFavouriteForCurrentUser(int userId, int recipeId)
		{
			return await db.UserFavourites
				.AnyAsync(uf => uf.UserId == userId && uf.RecipeId == recipeId);
		}

		public async Task<bool> IsLikedForCurrentUser(int userId, int recipeId)
		{
			return await db.RecipeLikes
				.AnyAsync(uf => uf.UserId == userId && uf.RecipeId == recipeId);
		}

		public async Task<bool> IsRepeatingImage(string path)
		{
			if (await db.Recipes.AnyAsync(r => r.Img == path))
			{
				return true;
			}

			return false;
		}

		public async Task<int> GetLikesNumber(int recipeId)
		{
			return await db.RecipeLikes.CountAsync(rl => rl.RecipeId == recipeId);
		}

		public async Task<bool> RemoveLike(int userId, int recipeId)
		{
			RecipeLike recipeLike = await db.RecipeLikes
				.FirstOrDefaultAsync(uf => uf.RecipeId == recipeId && uf.UserId == userId);
			if (recipeLike != null)
			{
				db.RecipeLikes.Remove(recipeLike);
				return true;
			}

			return false;
		}

		public async Task<List<Tag>> GetRecipeTags(int recipeId)
		{
			List<RecipeTag> recipeTags = await db.RecipeTags
				.Include(rt => rt.Tag)
				.Where(rt => rt.RecipeId == recipeId)
				.ToListAsync();
			if (recipeTags != null)
			{
				return recipeTags.ConvertAll(rt => rt.Tag);
			}

			return null;
		}

		public async Task<int> GetUserFavouritesNumber(List<Recipe> recipes)
		{
			int favouritesNumber = 0;
			foreach (Recipe recipe in recipes)
			{
				favouritesNumber += await GetFavouritesNumber(recipe.Id);
			}

			return favouritesNumber;
		}

		public async Task<int> GetUserLikesNumber(List<Recipe> recipes)
		{
			int likesNumber = 0;
			foreach (Recipe recipe in recipes)
			{
				likesNumber += await GetLikesNumber(recipe.Id);
			}

			return likesNumber;
		}

		//поиск по тэгам
	}
}

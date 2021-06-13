﻿using System.Collections.Generic;
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
			return await db.Recipes.OrderBy(r => r.Likes).FirstOrDefaultAsync();
		}

		public async Task<List<Recipe>> GetAllRecipes()
		{
			IQueryable<Recipe> recipes = db.Recipes
				.Include(r => r.Tags);
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
		}

		public async Task<List<Recipe>> GetAllUsersRecipes(int userId)
		{
			IQueryable<Recipe> recipes = db.Recipes
				.Include(r => r.Tags)
				.Where(r => r.UserId == userId);
			recipes = recipes.OrderBy(r => r.Likes);
			return await recipes.AsNoTracking().ToListAsync();
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
				.Include(r => r.Tags)
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

		public void Like(Recipe recipe)
		{
		}

		public async Task<Recipe> GetRecipeById(int recipeId)
		{
			return await db.Recipes
				.Include(r => r.Tags)
				.Include(r => r.Steps)
				.Include(r => r.Ingridients)
				.SingleOrDefaultAsync(r => r.Id == recipeId);
		}

		public Task<List<Recipe>> GetAllByTags(string[] tagNames)
		{
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
					user,
					recipeId,
					recipe
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

		public async Task<bool> IsFavourite(int userId, int recipeId)
		{
			return await db.UserFavourites
				.AnyAsync(uf => uf.UserId == userId && uf.RecipeId == recipeId);
		}

		//поиск по тэгам
		//likes
	}
}

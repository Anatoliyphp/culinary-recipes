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
			List<Recipe> recipes = await db.Recipes
				.Include(r => r.RecipeLikes)
				.OrderByDescending(r => r.RecipeLikes.Count)
				.ToListAsync();
			Recipe bestRecipe = recipes.FirstOrDefault();

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
				.Include(r => r.RecipeLikes)
				.Include(r => r.UserFavourites)
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

		public async Task<Recipe> GetRecipeById(int recipeId)
		{
			return await db.Recipes
				.Include(r => r.Steps)
				.Include(r => r.Ingridients)
				.Include(r => r.RecipeLikes)
				.Include(r => r.UserFavourites)
				.SingleOrDefaultAsync(r => r.Id == recipeId);
		}

		public async Task<List<Recipe>> SearchRecipes(int[] tagIds, string name)
		{
			List<RecipeTag> recipeTags = await db.RecipeTags
				.Include(rt => rt.Recipe)
				.Where(rt => (tagIds.Contains(rt.TagId) && EF.Functions.Like(rt.Recipe.Name, $"%{name}%") && name.Any())
				|| (tagIds.Contains(rt.TagId) && !name.Any())
				|| (EF.Functions.Like(rt.Recipe.Name, $"%{name}%") && name.Any()))
				.ToListAsync();
			List<Recipe> recipes = recipeTags.Select(rt => rt.Recipe).ToList();
			return recipes;
		}

		public async Task<List<Tag>> GetAllTags()
		{
			return await db.Tags.ToListAsync();
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
			return await db.Recipes.AnyAsync(r => r.Img == path);
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

		public async Task AddRecipeTags(int recipeId, List<string> TagNames)
		{
			foreach (string tagName in TagNames)
			{
				Tag existingTag = await db.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
				if (existingTag == null)
				{
					Tag tag = await db.Tags.AddAsync(new Tag(tagName));
					await db.RecipeTags.AddAsync(new RecipeTag(tag.Id, recipeId));
				}
				else
				{
					RecipeTag existingRecipeTag = await db.RecipeTags
						.FirstOrDefaultAsync(rt => rt.RecipeId == recipeId && rt.TagId == existingTag.Id);
					if (existingRecipeTag == null)
					{
						await db.RecipeTags.AddAsync(new RecipeTag(existingTag.Id, recipeId));
					}
				}
			}
		}

		public int GetUserFavouritesNumber(List<Recipe> recipes)
		{
			return recipes.Sum(r => r.UserFavourites.Count);
		}

		public int GetUserLikesNumber(List<Recipe> recipes)
		{
			return recipes.Sum(r => r.RecipeLikes.Count);
		}

		public Task<int> GetFavouritesNumber(int recipeId)
		{
			return db.UserFavourites.CountAsync(uf => uf.RecipeId == recipeId);
		}
	}
}

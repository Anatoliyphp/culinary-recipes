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
				.Include(r => r.Comments)
				.Include(r => r.UserFavourites)
				.OrderByDescending(r => r.RecipeLikes.Count + r.UserFavourites.Count + r.Comments.Count)
				.ToListAsync();
			Recipe bestRecipe = recipes.FirstOrDefault();

			return bestRecipe;
		}

		public async Task<List<Recipe>> GetAllRecipes(Filter filter)
		{
			List<Recipe> recipes = await db.Recipes
					.Include(r => r.Comments)
					.Include(r => r.RecipeLikes)
					.Include(r => r.UserFavourites)
					.ToListAsync();
			return GetAllRecipesFiltered(filter, recipes);
		}

		public async Task<List<Recipe>> GetAllUsersRecipes(int userId, Filter filter)
		{
			List<Recipe> recipes = await db.Recipes
				.Include(r => r.RecipeLikes)
				.Include(r => r.UserFavourites)
				.Include(r => r.Comments)
				.Where(r => r.UserId == userId).ToListAsync();
			return GetAllRecipesFiltered(filter, recipes);
		}

		public async Task<List<Recipe>> GetAllFavouritesRecipes(int userId, Filter filter)
		{
			List<UserFavourites> userFavourites = await db.UserFavourites
				.Include(uf => uf.Recipe)
				.ThenInclude(r => r.Comments)
				.Include(uf => uf.Recipe)
				.ThenInclude(r => r.RecipeLikes)
				.Include(uf => uf.Recipe)
				.ThenInclude(r => r.UserFavourites)
				.Where(uf => uf.UserId == userId)
				.ToListAsync();

			if (userFavourites == null)
			{
				return null;
			}
			return GetAllRecipesFiltered(filter, userFavourites.ConvertAll(r => r.Recipe));
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
				.Include(r => r.RecipeTags)
				.Include(r => r.Comments)
				.SingleOrDefaultAsync(r => r.Id == recipeId);
		}

		public async Task<List<Recipe>> SearchRecipes(int[] tagIds, string name, Filter filter)
		{
			List<int> recipeIds = db.RecipeTags
				.Where(rt => tagIds.Contains(rt.TagId))
				.ToList().ConvertAll(rt => rt.RecipeId);
			List<Recipe> recipes = new List<Recipe>();
			
			if (name.Length < 3)
			{
				recipes = await db.Recipes
					.Include(r => r.Comments)
					.Include(r => r.RecipeLikes)
					.Include(r => r.UserFavourites)	
					.Where(r => EF.Functions.Like(r.Name, $"%{name}%") || recipeIds.Contains(r.Id))
					.ToListAsync();
			}
			else
			{
				recipes = await db.Recipes
					.Include(r => r.Comments)
					.Include(r => r.RecipeLikes)
					.Include(r => r.UserFavourites)
					.Where(r => EF.Functions.FreeText(r.Name, name) || recipeIds.Contains(r.Id))
					.ToListAsync();
			}

			return recipes.Count == 1 ? recipes : GetAllRecipesFiltered(filter, recipes);
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

		public async Task AddTags(List<string> TagNames)
		{
			foreach(string tagName in TagNames)
			{
				if (!await db.Tags.AnyAsync(t => t.Name == tagName))
				{
					await db.Tags.AddAsync(new Tag(tagName));
				}
			}
		}

		public async Task AddRecipeTags(int recipeId, List<string> TagNames)
		{
			List<Tag> tags = await db.Tags
				.Where(t => TagNames.Contains(t.Name))
				.ToListAsync();
			foreach (Tag tag in tags)
			{
				await db.RecipeTags.AddAsync(new RecipeTag(tag.Id, recipeId));
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

		public int GetUserCommentsNumber(List<Recipe> recipes)
		{
			return recipes.Sum(r => r.Comments.Count);
		}

		public Task<int> GetFavouritesNumber(int recipeId)
		{
			return db.UserFavourites.CountAsync(uf => uf.RecipeId == recipeId);
		}

		public Task<int> GetRecipeCommentsNumber(int recipeId)
		{
			return db.Comments.CountAsync(c => c.RecipeId == recipeId);
		}

		public async Task<UserStats> GetUserStats(int userId)
		{
			List<User> users = await db.Users
				.Include(u => u.Recipes)
				.ThenInclude(r => r.Comments)
				.Include(u => u.Recipes)
				.ThenInclude(r => r.UserFavourites)
				.Include(u => u.Recipes)
				.ThenInclude(r => r.RecipeLikes).ToListAsync();

			return users
				.GroupBy(u => new { u.Id, u.Recipes })
				.Select(g => new UserStats
				{
					Id = g.Key.Id,
					RecipesNumber = g.Key.Recipes.Count,
					FavouritesNumber = g.Key.Recipes.Sum(r => r.UserFavourites.Count),
					CommentsNumber = g.Key.Recipes.Sum(r => r.Comments.Count),
					Likes = g.Key.Recipes.Sum(r => r.RecipeLikes.Count)
				}).FirstOrDefault(u => u.Id == userId);
		}

		public async Task AddComment(Comment comment)
		{
			await db.Comments.AddAsync(comment);
		}

		public void UpdateComment(Comment comment)
		{
			db.Comments.Update(comment);
		}

		public void RemoveComment(Comment comment)
		{
			db.Comments.Remove(comment);
		}

		public Task<List<Comment>> GetAllRecipeComments(int recipeId)
		{
			return db.Comments.Where(c => c.RecipeId == recipeId).ToListAsync();
		}

		public Task<Comment> GetCommentById(int commentId)
		{
			return db.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
		}
		
		private List<Recipe> GetAllRecipesFiltered(Filter filter, List<Recipe> recipes)
		{
			switch (filter)
			{
				case Filter.ByComments:
					return recipes
						.OrderByDescending(r => r.Comments.Count).ToList();
				case Filter.ByFavourites:
					return recipes
						.OrderByDescending(r => r.UserFavourites.Count).ToList();
				case Filter.ByLikes:
					return recipes
						.OrderByDescending(r => r.RecipeLikes.Count).ToList();
				default:
					throw new ArgumentOutOfRangeException("Incorrect filter type");
			}
		}

	}
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipe_domain;

public interface IRecipeRepository
{
    Task<Recipe> GetBestRecipe();

    Task AddComment(Comment comment);

    void UpdateComment(Comment comment);

    Task<List<Tag>> GetAllTags();

    Task<List<Recipe>> GetAllRecipes(Filter filter);

    Task AddRecipeTags(int recipeId, List<string> TagNames);

    Task<UserStats> GetUserStats(int userId);

    int GetUserFavouritesNumber(List<Recipe> recipes);

    int GetUserLikesNumber(List<Recipe> recipes);

    int GetUserCommentsNumber(List<Recipe> recipes);

    Task<int> GetRecipeCommentsNumber(int recipeId);

    Task<List<Recipe>> GetAllFavouritesRecipes(int userId, Filter filter);

    Task<List<Recipe>> GetAllUsersRecipes(int userId, Filter filter);

    Task<Recipe> GetRecipeById(int recipeId);

    Task AddRecipe(Recipe recipe);

    Task<bool> DeleteRecipe(int id);

    void RemoveComment(Comment comment);

    void ChangeRecipe(Recipe recipe);

    Task AddTags(List<string> TagNames);

    Task<bool> IsLikedForCurrentUser(int userID, int recipeId);

    Task<bool> IsFavouriteForCurrentUser(int userId, int recipeId);

    Task<bool> DeleteFromFavourites(int userID, int recipeId);

    Task<int> GetFavouritesNumber(int recipeId);

    Task<int> GetLikesNumber(int recipeId);

    Task<bool> RemoveLike(int userId, int recipeId);

    Task<List<Recipe>> SearchRecipes(int[] tagIds, string name, Filter filter);

    Task<bool> IsRepeatingImage(string path);

    Task<List<Tag>> GetRecipeTags(int recipeId);

    Task<List<Comment>> GetAllRecipeComments(int recipeId);

    Task<Comment> GetCommentById(int commentId);

}

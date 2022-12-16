using Abp.Domain.Entities;

namespace recipe_domain;

public class UserFavourites : Entity
{
    public UserFavourites(
        int userId,
        int recipeId
        )
    {
        UserId = userId;
        RecipeId = recipeId;
    }

    public int UserId { get; set; }
    public User User { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}


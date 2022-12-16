using System;
using Abp.Domain.Entities;

namespace recipe_domain;

public class Comment : Entity
{
    public Comment(
        string text,
        DateTime time,
        int recipeId,
        int userId
        )
    {
        Text = text;
        Time = time;
        RecipeId = recipeId;
        UserId = userId;
    }

    public Comment(string text)
    {
        Text = text;
    }

    public string Text { get; set; }

    public DateTime Time { get; set; }

    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}

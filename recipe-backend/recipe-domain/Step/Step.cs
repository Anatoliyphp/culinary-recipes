using Abp.Domain.Entities;

namespace recipe_domain;

public class Step : Entity
{
    public Step(string name, string desc, int recipeId)
    {
        Name = name;
        Desc = desc;
        RecipeId = recipeId;
    }

    public string Name { get; set; }

    public string Desc { get; set; }

    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}


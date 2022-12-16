using Abp.Domain.Entities;

namespace recipe_domain;

public class Ingridient : Entity
{
    public Ingridient(string name, string list, int recipeId)
    {
        Name = name;
        List = list;
        RecipeId = recipeId;
    }

    public string Name { get; set; }

    public string List { get; set; }

    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}


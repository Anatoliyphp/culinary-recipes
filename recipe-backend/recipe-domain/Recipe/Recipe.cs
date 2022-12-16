using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;

namespace recipe_domain;

public class Recipe : Entity, IAggregateRoot
{
    public Recipe(
        string img,
        string name,
        string description,
        int time,
        int persons,
        int userId
        )
    {
        Img = img;
        Name = name;
        Description = description;
        Time = time;
        Persons = persons;
        UserId = userId;
    }

    public string Img { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Time { get; set; }

    public int Persons { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public List<RecipeLike> RecipeLikes { get; set; }

    public List<UserFavourites> UserFavourites { get; set; }

    public List<Step> Steps = new List<Step>();

    public readonly List<Comment> Comments = new List<Comment>();

    public List<RecipeTag> RecipeTags { get; set; }

    public List<Ingridient> Ingridients = new List<Ingridient>();

    public void Like(int userId)
    {
        RecipeLikes.Add(new RecipeLike(userId, Id));
    }

    public void AddToFavourites(int userId)
    {
        UserFavourites.Add(new UserFavourites(userId, Id));
    }

    public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
}
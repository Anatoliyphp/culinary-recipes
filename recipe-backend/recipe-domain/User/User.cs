using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;

namespace recipe_domain
{
    public class User: Entity, IAggregateRoot
    {
	    
	    /*
	     * Добавить аватар и в ui добавить карточку пользователя со статистикой и ссылкой на лучший его рецепт
	     * Добавить топ пользователей с этими карточками
	     */
        public User(string login, string password, string name)
		{
            Login = login;
            Password = password;
            Name = name;
		}

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public readonly List<Recipe> Recipes = new List<Recipe>();

        public readonly List<Comment> Comments = new List<Comment>();

        public List<UserFavourites> UserFavourites { get; set; }

        public List<RecipeLike> RecipeLikes { get; set; }

        public List<Recipe> GetRecipes()
		{
            return Recipes;
		}

        public void AddRecipe(
            string img,
            string name,
            string desc,
            int time,
            int likes,
            int persons
            )
		{
            Recipes.Add(new Recipe(img, name, desc, time, persons, Id));
		}

		public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
	}
}

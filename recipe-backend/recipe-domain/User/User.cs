using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;
using System.Linq;

namespace recipe_domain
{
    public class User: Entity, IAggregateRoot
    {
        public User(string login, string password, string name)
		{
            Login = login;
            Password = password;
            Name = name;
		}

        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        private readonly List<Recipe> Recipes = new List<Recipe>();

        public List<Recipe> Favourites { get; set; }

        public List<Recipe> GetRecipes()
		{
            return Recipes;
		}

        public void AddRecipe(
            byte[] img,
            string name,
            string desc,
            int time,
            int persons
            )
		{
            Recipes.Add(new Recipe(img, name, desc, time, persons, UserId));
		}

		public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
	}
}

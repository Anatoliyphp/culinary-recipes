﻿using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;

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

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public readonly List<Recipe> Recipes = new List<Recipe>();

        public List<UserFavourites> UserFavourites { get; set; }

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
            Recipes.Add(new Recipe(img, name, desc, time, persons, Id));
		}

		public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
	}
}

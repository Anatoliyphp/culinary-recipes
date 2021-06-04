using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;
using System.Linq;

namespace recipe_domain
{
	public class Recipe: Entity, IAggregateRoot
	{
		public Recipe(
			byte[] img,
			string name,
			string desc,
			int time,
			int persons,
			int userId
			)
		{
			Img = img;
			Name = name;
			Desc = desc;
			Time = time;
			Persons = persons;
			Likes = 0;
			UserId = userId;
		}
		public int RecipeId { get; set; }

		public byte[] Img { get; set; }

		public string Name { get; set; }

		public string Desc { get; set; }

		public int Time { get; set; }

		public int Persons { get; set; }

		public int Likes { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public List<User> Users { get; set; }

		private List<Step> Steps = new List<Step>();

		private List<Tag> Tags = new List<Tag>();

		private List<Ingridient> Ingridients = new List<Ingridient>();

		public void AddStep(string name, string desc)
		{
			if (!Steps.Any(s => s.Name == name))
			{
				Steps.Add(new Step(name, desc, RecipeId));
			}
		}

		public void AddTag(string name)
		{
			if (!Tags.Any(t => t.Name == name))
			{
				Tags.Add(new Tag(name));
			}
		}

		public void AddIngridient(string name, string list)
		{
			if (!Ingridients.Any(i => i.Name == Name))
			{
				Ingridients.Add(new Ingridient(name, list, RecipeId));
			}
		}

		public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
	}
}

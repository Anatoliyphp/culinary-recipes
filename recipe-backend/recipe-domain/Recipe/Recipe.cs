using Abp.Domain.Entities;
using Abp.Events.Bus;
using System.Collections.Generic;
using System.Linq;

namespace recipe_domain
{
	public class Recipe: Entity, IAggregateRoot
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

		public List<Tag> Tags = new List<Tag>();

		public List<Ingridient> Ingridients = new List<Ingridient>();

		public void AddStep(string name, string desc)
		{
			if (!Steps.Any(s => s.Name == name))
			{
				Steps.Add(new Step(name, desc, Id));
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
				Ingridients.Add(new Ingridient(name, list, Id));
			}
		}

		public ICollection<IEventData> DomainEvents => throw new System.NotImplementedException();
	}
}

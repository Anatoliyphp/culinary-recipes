using System.Collections.Generic;

namespace recipe_domain
{
	public class Recipe
	{
		public int RecipeId { get; set; }
		public byte[] Img { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public string Time { get; set; }
		public int Persons { get; set; }
		public int Likes { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public ICollection<User> Users { get; set; }
		public List<Step> Steps { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public List<Ingridient> Ingridients { get; set; }
	}
}

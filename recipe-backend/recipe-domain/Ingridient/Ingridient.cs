namespace recipe_domain
{
	public class Ingridient
	{
		public int IngridientId { get; set; }
		public string Name { get; set; }
		public string List { get; set; }
		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
	}
}

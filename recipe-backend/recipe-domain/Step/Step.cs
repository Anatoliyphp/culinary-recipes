namespace recipe_domain
{
	public class Step
	{
		public int StepId { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
	}
}

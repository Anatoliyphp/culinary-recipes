using Abp.Domain.Entities;

namespace recipe_domain
{
	public class RecipeTag: Entity
	{
		public RecipeTag(
				int tagId,
				int recipeId
				)
		{
			TagId = tagId;
			RecipeId = recipeId;
		}

		public int TagId { get; set; }
		public Tag Tag { get; set; }

		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
	}
}

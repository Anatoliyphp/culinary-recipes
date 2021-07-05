using Application;
using recipe_domain;

namespace recipe_api.Recipes.Mappers
{
	public static class TagMapper
	{
		public static TagDto Map(Tag tag)
		{
			return new TagDto(
					tag.Id,
					tag.Name
				);
		}
	}
}

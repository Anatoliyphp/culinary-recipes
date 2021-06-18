using Application;
using recipe_domain;

namespace recipe_api.Recipes.Mappers
{
	public static class IngridientMapper
	{
		public static IngridientDto Map(Ingridient ingridient)
		{
			return new IngridientDto(
					ingridient.Name,
					ingridient.List
				);
		}
	}
}

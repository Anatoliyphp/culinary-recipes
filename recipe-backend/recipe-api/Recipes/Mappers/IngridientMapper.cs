using Application;
using recipe_domain;

namespace recipe_api.Recipes.Mappers
{
	public static class IngridientMapper
	{
		public static IngridientDto Map(Ingridient ingridient)
		{
			IngridientDto ingridientDto = new IngridientDto();
			ingridientDto.Name = ingridient.Name;
			ingridientDto.List = ingridient.List;
			return ingridientDto;
		}
	}
}

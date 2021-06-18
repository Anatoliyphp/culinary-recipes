using Application;
using recipe_domain;

namespace recipe_api.Recipes.Mappers
{
	public static class StepMapper
	{
		public static StepDto Map(Step step)
		{
			return new StepDto(
					step.Name,
					step.Desc
				);
		}
	}
}

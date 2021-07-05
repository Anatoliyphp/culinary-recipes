using Application;
using recipe_domain;

namespace recipe_api.Recipes.Mappers
{
	public static class StepMapper
	{
		public static StepDto Map(Step step)
		{
			StepDto stepDto = new StepDto();
			stepDto.Name = step.Name;
			stepDto.Desc = step.Desc;
			return stepDto;
		}
	}
}

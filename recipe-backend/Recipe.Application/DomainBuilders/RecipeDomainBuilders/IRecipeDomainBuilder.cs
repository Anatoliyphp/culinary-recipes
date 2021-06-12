using recipe_domain;

namespace Application
{
	public interface IRecipeDomainBuilder
	{
		Recipe CreateRecipe(FullRecipeDto fullRecipeDto);
	}
}

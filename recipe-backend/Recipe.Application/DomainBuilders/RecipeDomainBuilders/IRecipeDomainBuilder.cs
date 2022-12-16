using recipe_domain;

namespace Application
{
	public interface IRecipeDomainBuilder
	{
		Recipe CreateRecipe(FullRecipeRequestDto fullRecipeDto, string img);
		Comment CreateComment(CommentDto commentDto, int recipeId, int userId);
		Comment CreateComment(CommentDto commentDto);
	}
}

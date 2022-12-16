using System;
using Microsoft.Extensions.Logging;
using recipe_domain;

namespace Application
{
	public class RecipeDomainBuilder : IRecipeDomainBuilder
	{
		private readonly ILogger<RecipeDomainBuilder> _logger;

		public RecipeDomainBuilder(ILogger<RecipeDomainBuilder> logger)
		{
			_logger = logger;
		}

		public Recipe CreateRecipe(FullRecipeRequestDto recipeDto, string img)
		{
			if (recipeDto != null)
			{
				Recipe recipe = new Recipe (
					img,
					recipeDto.Name,
					recipeDto.Description,
					recipeDto.Time,
					recipeDto.Persons,
					recipeDto.UserId
				);
				recipe.Steps = recipeDto.Steps
					.ConvertAll(s => new Step(s.Name, s.Desc, recipe.Id));
				recipe.Ingridients = recipeDto.Ingridients
					.ConvertAll(i => new Ingridient(i.Name, i.List, recipe.Id));

				foreach(Step step in recipe.Steps)
				{
					try
					{
						IValidator<Step> validator = new StepValidator();
						validator.Validate(step);
					}
					catch (Exception e)
					{
						_logger.LogError(e.Message);
					}
				}

				foreach(Ingridient ingridient in recipe.Ingridients)
				{
					try
					{
						IValidator<Ingridient> validator = new IngridientValidator();
						validator.Validate(ingridient);
					}
					catch (Exception e)
					{
						_logger.LogError(e.Message);
					}
				}

				try
				{
					IValidator<Recipe> validator = new RecipeValidator();
					validator.Validate(recipe);
				}
				catch (Exception e)
				{
					_logger.LogError(e.Message);
				}

				return recipe;

			}
			return null;
		}

		public Comment CreateComment(CommentDto commentDto, int recipeId, int userId)
		{
			if (commentDto == null)
			{
				return null;
			}

			Comment comment = new Comment(
					commentDto.Text,
					DateTime.ParseExact(
						commentDto.Time,
						"yyyy.MM.dd H:mm:ss",
						System.Globalization.CultureInfo.InvariantCulture
					),
					recipeId,
					userId
				)
				{Id = commentDto.Id};

			try
			{
				IValidator<Comment> validator = new CommentValidator();
				validator.Validate(comment);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return comment;
		}
		
		public Comment CreateComment(CommentDto commentDto)
		{
			if (commentDto == null)
			{
				return null;
			}

			Comment comment = new Comment(
					commentDto.Text
				)
				{Id = commentDto.Id};

			try
			{
				IValidator<Comment> validator = new CommentValidator();
				validator.Validate(comment);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return comment;
		}
	}
}

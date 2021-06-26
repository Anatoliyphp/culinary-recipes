using Application;
using recipe_domain;
using System.Linq;
using System.Threading.Tasks;
using recipe_api.Recipes.Mappers;
using recipe_api.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace recipe_api
{
	public class RecipesDtoBuilder : IRecipesDtoBuilder
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IImageService _imageService;

		public RecipesDtoBuilder(
			IRecipeRepository recipeRepository,
			IImageService imageService
			)
		{
			_recipeRepository = recipeRepository;
			_imageService = imageService;
		}

		public async Task<BestRecipeDto> CreateBestRecipe(Recipe recipe)
		{
			int likes = await _recipeRepository.GetLikesNumber(recipe.Id);
			if (recipe != null)
			{
				string img = await _imageService.GetImage(recipe.Img);
				return new BestRecipeDto
				(
					recipe.Id,
					img,
					recipe.Name,
					recipe.Description,
					recipe.Time,
					likes,
					recipe.UserId
				);
			}

			return null;
		}

		public async Task<FullRecipeResponseDto> CreateFullRecipeDto(int recipeId, int userId)
		{
			Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
			if (recipe != null)
			{
				string img = await _imageService.GetImage(recipe.Img);
				int favouritesNumber = await _recipeRepository.GetFavouritesNumber(recipeId);
				bool isFavourite = await _recipeRepository.IsFavouriteForCurrentUser(userId, recipeId);
				int likes = await _recipeRepository.GetLikesNumber(recipeId);
				bool isLike = await _recipeRepository.IsLikedForCurrentUser(userId, recipeId);
				List<Tag> tags = await _recipeRepository.GetRecipeTags(recipeId);
				return new FullRecipeResponseDto
				(
					recipeId,
					img,
					recipe.Name,
					recipe.Description,
					recipe.Time,
					recipe.Persons,
					likes,
					isLike,
					favouritesNumber,
					isFavourite,
					recipe.UserId,
					tags.ConvertAll(
						t => new TagDto(t.Id, t.Name)),
					recipe.Ingridients.Select(
						i => IngridientMapper.Map(i)).ToList(),
					recipe.Steps.Select(
						s => StepMapper.Map(s)).ToList()
				);
			}
			return null;
		}

		public async Task<RecipeDto> CreateRecipeDto(Recipe recipe, int userId)
		{
			if (recipe != null)
			{
				int favouritesNumber = await _recipeRepository.GetFavouritesNumber(recipe.Id);
				bool isFavourite = await _recipeRepository.IsFavouriteForCurrentUser(userId, recipe.Id);
				int likes = await _recipeRepository.GetLikesNumber(recipe.Id);
				bool isLike = await _recipeRepository.IsLikedForCurrentUser(userId, recipe.Id);
				string img = await _imageService.GetImage(recipe.Img);
				List<Tag> tags = await _recipeRepository.GetRecipeTags(recipe.Id);
				return new RecipeDto
				(
					recipe.Id,
					img,
					recipe.Name,
					recipe.Description,
					recipe.Time,
					recipe.Persons,
					likes,
					isLike,
					favouritesNumber,
					isFavourite,
					recipe.UserId,
					tags.ConvertAll(
						t => new TagDto(t.Id, t.Name))
				);
			}
			return null;
		}
	}
}

using Application;
using recipe_domain;
using System.Linq;
using System.Threading.Tasks;
using recipe_api.Recipes.Mappers;
using recipe_api.Services;
using Microsoft.AspNetCore.Http;

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

		public async Task<FullRecipeDto> CreateFullRecipeDto(int recipeId, int userId)
		{
			Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
			if (recipe != null)
			{
				IFormFile img = null; //= await _imageService.GetImage(recipe.Img);
				int favouritesNumber = await _recipeRepository.GetFavouritesNumber(recipeId);
				bool isFavourite = await _recipeRepository.IsFavouriteForCurrentUser(userId, recipeId);
				int likes = await _recipeRepository.GetLikesNumber(recipeId);
				bool isLike = await _recipeRepository.IsLikedForCurrentUser(userId, recipeId);
				return new FullRecipeDto
				(
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
					recipe.Tags.Select(
						t => TagMapper.Map(t)).ToList(),
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
					recipe.Tags.Select(
						t => TagMapper.Map(t)).ToList()
				);
			}
			return null;
		}
	}
}

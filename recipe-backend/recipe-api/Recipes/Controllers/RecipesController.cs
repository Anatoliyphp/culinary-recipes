using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recipe_domain;
using Application;
using System.Collections.Generic;
using recipe_infrastructure.UoW;
using Microsoft.AspNetCore.Http;
using recipe_api.Services;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace recipe_api.Recipes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeDomainBuilder _recipeDomainBuilder;
		private readonly IRecipesDtoBuilder _recipesDtoBuilder;
		private readonly UnitOfWork _unitOfWork;
		private readonly IImageService _imageService;
		public RecipesController(
			IRecipeRepository recipeRepository,
			IRecipesDtoBuilder recipesDtoBuilder,
			IRecipeDomainBuilder recipeDomainBuilder,
			UnitOfWork unitOfWork,
			IImageService imageService,
			ILogger<RecipesController> logger
			)
		{
			_recipeRepository = recipeRepository;
			_recipeDomainBuilder = recipeDomainBuilder;
			_recipesDtoBuilder = recipesDtoBuilder;
			_unitOfWork = unitOfWork;
			_imageService = imageService;
			_logger = logger;
		}

		[Route("add")]
		[HttpPost]
		public async Task<IActionResult> AddRecipe([FromBody]FullRecipeRequestDto request)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation("Creating recipe from request...");
			string imgPath = await _imageService.AddImage(request.Img);
			Recipe recipe = _recipeDomainBuilder.CreateRecipe(request, imgPath);
			if (recipe == null)
			{
				_logger.LogError($"Recipe with name: {request.Name} failed to created");
				return BadRequest($"Can't add recipe with name:{request.Name}");
			}

			await _recipeRepository.AddRecipe(recipe);
			await _unitOfWork.Save();
			_logger.LogInformation("Recipe was created");
			return Ok();

		}

		[Route("fullrecipe/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> GetFullRecipe(int userId, int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Creating model for recipe with id: {recipeId} ");
			FullRecipeResponseDto fullRecipeDto = await _recipesDtoBuilder
				.CreateFullRecipeDto(recipeId, userId);

			if (fullRecipeDto == null)
			{
				_logger.LogError("Failed to creating model");
				return BadRequest($"Can't get full recipe with id:{recipeId}");
			}

			_logger.LogInformation("Recipe created");
			return Ok(fullRecipeDto);
		}

		[Route("edit")]
		[HttpPost]
		public async Task<IActionResult> EditRecipe([FromBody] FullRecipeRequestDto request)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			string imgPath = await _imageService.AddImage(request.Img);
			Recipe recipe = _recipeDomainBuilder.CreateRecipe(request, imgPath);
			if (recipe == null)
			{
				_logger.LogError($"Failed to edit recipe with id: {request.Id}");
				return BadRequest($"Can't edit recipe with name:{request.Name}");
			}

			_recipeRepository.ChangeRecipe(recipe);
			await _unitOfWork.Save();
			_logger.LogInformation("Recipe edited");
			return Ok();

		}

		[Route("delete/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> DeleteRecipe(int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Deleting recipe with id: {recipeId}...");
			bool isDeleted = await _recipeRepository.DeleteRecipe(recipeId);
			await _unitOfWork.Save();
			if (!isDeleted)
			{
				_logger.LogError("Failed to delete recipe");
				return BadRequest($"Can't delete recipe with id:{recipeId}");
			}

			_logger.LogInformation("Recipe deleted");
			return Ok();

		}

		[Route("allRecipes/{userId:int}")]
		[HttpGet]
		public async Task<IActionResult> GetAllRecipes(int userId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation("Getting all recipes...");
			List<Recipe> recipes = await _recipeRepository.GetAllRecipes();
			if (recipes == null)
			{
				_logger.LogWarning("Any Recipes not found");
				return BadRequest("Can't get all recipes");
			}

			List<RecipeDto> recipeDtos = new List<RecipeDto>();
			foreach (Recipe recipe in recipes)
			{
				RecipeDto recipeDto = await _recipesDtoBuilder.CreateRecipeDto(recipe, userId);
				recipeDtos.Add(recipeDto);
			}

			recipeDtos = recipeDtos.OrderByDescending(rd => rd.Likes).ToList();

			_logger.LogInformation("Recipes successfully getted");
			return Ok(recipeDtos);

		}

		[Route("favourites/{userId:int}")]
		[HttpGet]
		public async Task<IActionResult> GetFavouritesRecipes(int userId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Getting favourites for user with id: {userId}");
			List<Recipe> recipes = await _recipeRepository.GetAllFavouritesRecipes(userId);
			if (recipes == null)
			{
				_logger.LogWarning("Favourites not found");
				return BadRequest($"Can't get favourites for user with id:{userId}");
			}

			List<RecipeDto> recipeDtos = new List<RecipeDto>();
			foreach (Recipe recipe in recipes)
			{
				RecipeDto recipeDto = await _recipesDtoBuilder.CreateRecipeDto(recipe, userId);
				recipeDtos.Add(recipeDto);
			}

			recipeDtos = recipeDtos.OrderByDescending(rd => rd.Likes).ToList();

			_logger.LogInformation("Favourites successfully getted");
			return Ok(recipeDtos);
			
		}

		[Route("addFavourites/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> AddToFavourites(int userId, int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Adding to user with id: {userId} favourites recipe with id: {recipeId}...");
			bool IsAdded = await _recipeRepository.AddToFavourites(userId, recipeId);
			await _unitOfWork.Save();

			if (!IsAdded)
			{
				_logger.LogWarning("Failed to add recipe to favourites");
				return BadRequest(
					$"Can't add recipe with id:{recipeId}" +
					$" to user favourites with id:{userId}"
				);
			}

			_logger.LogInformation("Recipe successfully added to favourites");
			return Ok();

		}

		[Route("deleteFavourites/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> DeleteFromFavourites(int userId, int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Deleting from user with id: {userId} favourites recipe with id: {recipeId}...");
			bool IsDeleted = await _recipeRepository.DeleteFromFavourites(userId, recipeId);
			await _unitOfWork.Save();
			if (!IsDeleted)
			{
				_logger.LogError("Failed to delete recipe from favourites");
				return BadRequest(
					$"Can't delete recipe with id:{recipeId}" +
					$" from user favourites with id:{userId}"
				);
			}

			_logger.LogInformation("Recipe successfully deleted from favourites");
			return Ok();

		}

		[Route("userRecipes/{userId:int}")]
		[HttpGet]
		public async Task<IActionResult> GetUserRecipes(int userId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Getting recipes for user with id: {userId}");
			List<Recipe> recipes = await _recipeRepository.GetAllUsersRecipes(userId);
			if (recipes == null)
			{
				_logger.LogWarning("Recipes not found");
				return BadRequest($"Can't get recipes for user with id:{userId}");
			}

			List<RecipeDto> recipeDtos = new List<RecipeDto>();
			foreach (Recipe recipe in recipes)
			{
				RecipeDto recipeDto = await _recipesDtoBuilder.CreateRecipeDto(recipe, userId);
				recipeDtos.Add(recipeDto);
			}

			recipeDtos = recipeDtos.OrderByDescending(rd => rd.Likes).ToList();

			_logger.LogInformation("Recipes successufully getted");
			return Ok(recipeDtos);

		}

		[Route("bestRecipe")]
		[HttpPost]
		public async Task<IActionResult> GetBestRecipe()
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation("Getting best recipe...");
			Recipe recipe = await _recipeRepository.GetBestRecipe();
			BestRecipeDto recipeDto = await _recipesDtoBuilder.CreateBestRecipe(recipe);
			if (recipeDto == null)
			{
				_logger.LogWarning("Best recipe not found");
				return BadRequest($"Can't get best recipe");
			}

			_logger.LogInformation("Best recipe getted");
			return Ok(recipeDto);

		}

		[Route("search/{userId:int}/{name}")]
		[HttpGet]
		public async Task<IActionResult> SearchRecipe(int userId, string name)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Searching recipes with name: {name}");
			List<Recipe> recipes = await _recipeRepository.GetAllRecipesByName(name);

			if (recipes == null)
			{
				_logger.LogWarning("Recipes not found");
				return BadRequest();
			}

			List<RecipeDto> recipeDtos = new List<RecipeDto>();
			foreach (Recipe recipe in recipes)
			{
				RecipeDto recipeDto = await _recipesDtoBuilder.CreateRecipeDto(recipe, userId);
				recipeDtos.Add(recipeDto);
			}

			recipeDtos = recipeDtos.OrderByDescending(rd => rd.Likes).ToList();

			_logger.LogInformation("Recipes found");
			return Ok(recipeDtos);
			
		}

		[Route("addLike/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> AddLike(int userId, int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Adding like to recipe with id: {recipeId} from user with id: {userId}");
			bool isAdded = await _recipeRepository.Like(userId, recipeId);
			await _unitOfWork.Save();

			if (!isAdded)
			{
				_logger.LogError("Can't add like");
				return BadRequest(
					$"Can't add like to recipe with id: " +
					$"{recipeId} from user with id: {userId}"
					);
			}

			_logger.LogInformation("Like added");
			return Ok();
		}

		[Route("removeLike/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> RemoveLike(int userId, int recipeId)
		{
			_logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

			_logger.LogInformation($"Deleting like from recipe with id: {recipeId} from user with id: {userId}");
			bool isDeleted = await _recipeRepository.RemoveLike(userId, recipeId);
			await _unitOfWork.Save();

			if (!isDeleted)
			{
				_logger.LogError("Can't remove like");
				return BadRequest(
					$"Can't remove like from recipe with id: " +
					$"{recipeId} from user with id: {userId}"
					);
			}

			_logger.LogInformation("Like removed");
			return Ok();
		}

		[Route("stats/{userId:int}")]
		[HttpGet]
		public async Task<IActionResult> GetUserStats(int userId)
		{
			List<Recipe> recipes = await _recipeRepository.GetAllUsersRecipes(userId);
			int numberOfUserRecipes = recipes.Count;
			int numberOfUserFavourites = await _recipeRepository.GetUserFavouritesNumber(recipes);
			int numberOfUserLikes = await _recipeRepository.GetUserLikesNumber(recipes);

			return Ok(
				new
				{
					recipes = numberOfUserRecipes,
					likes = numberOfUserLikes,
					favourites = numberOfUserFavourites
				}
			);
		}

	}
}

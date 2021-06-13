using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recipe_domain;
using Application;
using System.Collections.Generic;
using recipe_infrastructure.UoW;

namespace recipe_api.Recipes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeDomainBuilder _recipeDomainBuilder;
		private readonly IRecipesDtoBuilder _recipesDtoBuilder;
		private readonly UnitOfWork _unitOfWork;
		public RecipesController(
			IRecipeRepository recipeRepository,
			IRecipesDtoBuilder recipesDtoBuilder,
			IRecipeDomainBuilder recipeDomainBuilder,
			UnitOfWork unitOfWork
			)
		{
			_recipeRepository = recipeRepository;
			_recipeDomainBuilder = recipeDomainBuilder;
			_recipesDtoBuilder = recipesDtoBuilder;
			_unitOfWork = unitOfWork;
		}

		[Route("add")]
		[HttpPost]
		public async Task<IActionResult> AddRecipe([FromBody]FullRecipeDto request)
		{
			Recipe recipe = _recipeDomainBuilder.CreateRecipe(request);
			if (recipe != null)
			{
				await _recipeRepository.AddRecipe(recipe);
				await _unitOfWork.Save();
				return Ok();
			}

			return BadRequest();
		}

		[Route("fullrecipe/{userId:int}/{recipeId:int}")]
		[HttpPost]
		public async Task<IActionResult> GetFullRecipe(int userId, int recipeId)
		{
			FullRecipeDto fullRecipeDto = await _recipesDtoBuilder
				.CreateFullRecipeDto(recipeId, userId);

			if (fullRecipeDto != null)
			{
				return Ok(fullRecipeDto);
			}

			return BadRequest();
		}

		[Route("edit")]
		[HttpPost]
		public async Task<IActionResult> EditRecipe([FromBody] FullRecipeDto request)
		{
			Recipe recipe = _recipeDomainBuilder.CreateRecipe(request);
			if (recipe != null)
			{
				_recipeRepository.ChangeRecipe(recipe);
				await _unitOfWork.Save();
				return Ok();
			}

			return BadRequest();
		}

		[Route("delete/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			bool isDeleted = await _recipeRepository.DeleteRecipe(id);
			await _unitOfWork.Save();
			if (isDeleted)
			{
				return Ok();
			}

			return BadRequest();
		}

		[Route("allRecipes/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> GetAllRecipes(int id)
		{
			List<Recipe> recipes = await _recipeRepository.GetAllRecipes();
			if (recipes != null)
			{
				List<Task<RecipeDto>> recipeDtos = recipes
					.ConvertAll(async r => await _recipesDtoBuilder.CreateRecipeDto(r, id));

				return Ok(recipeDtos);
			}
			return BadRequest();
		}

		[Route("favourites/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> GetFavouritesRecipes(int id)
		{
			List<Recipe> recipes = await _recipeRepository.GetAllFavouritesRecipes(id);
			if (recipes != null)
			{
				List<Task<RecipeDto>> recipeDtos = recipes
					.ConvertAll(async r => await _recipesDtoBuilder.CreateRecipeDto(r, id));

				return Ok(recipeDtos);
			}
			return BadRequest();
		}

		[Route("addFavourites/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> AddToFavourites(int userId, int recipeId)
		{
			bool IsAdded = await _recipeRepository.AddToFavourites(userId, recipeId);
			if (IsAdded)
			{
				await _unitOfWork.Save();
				return Ok();
			}
			return BadRequest();
		}

		[Route("deleteFavourites/{userId:int}/{recipeId:int}")]
		[HttpGet]
		public async Task<IActionResult> DeleteFromFavourites(int userId, int recipeId)
		{
			bool IsDeleted = await _recipeRepository.DeleteFromFavourites(userId, recipeId);
			if (IsDeleted)
			{
				await _unitOfWork.Save();
				return Ok();
			}
			return BadRequest();
		}

		[Route("userRecipes/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> GetUserRecipes(int id)
		{
			List<Recipe> recipes = await _recipeRepository.GetAllUsersRecipes(id);
			if (recipes != null)
			{
				List<Task<RecipeDto>> recipeDtos = recipes
					.ConvertAll(async r => await _recipesDtoBuilder.CreateRecipeDto(r, id));

				return Ok(recipeDtos);
			}
			return BadRequest();
		}

		[Route("bestRecipe")]
		[HttpPost]
		public async Task<IActionResult> GetBestRecipe()
		{
			Recipe recipe = await _recipeRepository.GetBestRecipe();
			RecipeDto recipeDto = await _recipesDtoBuilder.CreateRecipeDto(recipe, 0);

			if (recipeDto != null)
			{
				return Ok(recipeDto);
			}

			return BadRequest();
		}

		[Route("search/{id:int}/{name:string}")]
		[HttpGet]
		public async Task<IActionResult> SearchRecipe(int id, string name)
		{
			List<Recipe> recipes = await _recipeRepository.GetAllRecipesByName(name);

			if (recipes != null)
			{
				List<Task<RecipeDto>> recipeDtos = recipes
					.ConvertAll(async r => await _recipesDtoBuilder.CreateRecipeDto(r, id));

				return Ok(recipeDtos);
			}

			return BadRequest();
		}

	}
}

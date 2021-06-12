using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recipe_domain;
using Application;
using System.Collections.Generic;

namespace recipe_api.Recipes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeDomainBuilder _recipeDomainBuilder;
		private readonly IRecipesDtoBuilder _recipesDtoBuilder;
		public RecipesController(
			IRecipeRepository recipeRepository,
			IRecipesDtoBuilder recipesDtoBuilder,
			IRecipeDomainBuilder recipeDomainBuilder
			)
		{
			_recipeRepository = recipeRepository;
			_recipeDomainBuilder = recipeDomainBuilder;
			_recipesDtoBuilder = recipesDtoBuilder;
		}

		[Route("add")]
		[HttpPost]
		public async Task<IActionResult> AddRecipe([FromBody]FullRecipeDto request)
		{
			Recipe recipe = _recipeDomainBuilder.CreateRecipe(request);
			if (recipe != null)
			{
				await _recipeRepository.AddRecipe(recipe);
				return Ok();
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
				await _recipeRepository.ChangeRecipe(recipe);
				return Ok();
			}

			return BadRequest();
		}

		[Route("delete/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			bool isDeleted = await _recipeRepository.DeleteRecipe(id);
			if (isDeleted)
			{
				return Ok();
			}

			return BadRequest();
		}

		[Route("allRecipes")]
		[HttpPost]
		public async Task<IActionResult> GetAllRecipes()
		{
			List<Recipe> recipes = await _recipeRepository.GetAllRecipes();
			if (recipes != null)
			{
				List<RecipeDto> recipeDtos = recipes
					.ConvertAll(r => _recipesDtoBuilder.CreateRecipeDto(r));

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
				List<RecipeDto> recipeDtos = recipes
					.ConvertAll(r => _recipesDtoBuilder.CreateRecipeDto(r));

				return Ok(recipeDtos);
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
				List<RecipeDto> recipeDtos = recipes
					.ConvertAll(r => _recipesDtoBuilder.CreateRecipeDto(r));

				return Ok(recipeDtos);
			}
			return BadRequest();
		}

		[Route("bestRecipe")]
		[HttpPost]
		public async Task<IActionResult> GetBestRecipe()
		{
			Recipe recipe = await _recipeRepository.GetBestRecipe();

			if (recipe != null)
			{
				return Ok(recipe);
			}

			return BadRequest();
		}
	}
}

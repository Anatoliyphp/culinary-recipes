using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using recipe_api.Recipes.Builders;
using recipe_api.Services;
using recipe_infrastructure.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_api.Recipes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly ILogger<RecipesController> _logger;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeDomainBuilder _recipeDomainBuilder;
    private readonly IRecipesDtoBuilder _recipesDtoBuilder;
    private readonly UnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly RecipeUpdateBuilder _recipeUpdateBuilder;

    public RecipesController(
        IRecipeRepository recipeRepository,
        IRecipesDtoBuilder recipesDtoBuilder,
        IRecipeDomainBuilder recipeDomainBuilder,
        UnitOfWork unitOfWork,
        IImageService imageService,
        ILogger<RecipesController> logger,
        RecipeUpdateBuilder recipeUpdateBuilder
        )
    {
        _recipeRepository = recipeRepository;
        _recipeDomainBuilder = recipeDomainBuilder;
        _recipesDtoBuilder = recipesDtoBuilder;
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _logger = logger;
        _recipeUpdateBuilder = recipeUpdateBuilder;
    }

    [Route("add")]
    [HttpPost]
    public async Task<IActionResult> AddRecipe([FromForm] FullRecipeRequestDto request)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation("Creating recipe from request...");
        string imgPath = await _imageService.AddImage(request.Img);
        Recipe recipe = _recipeDomainBuilder.CreateRecipe(request, imgPath);
        if (recipe == null || recipe.Img == null)
        {
            _logger.LogError($"Recipe with name: {request.Name} failed to created");
            return BadRequest($"Can't add recipe with name:{request.Name}");
        }
        await _recipeRepository.AddRecipe(recipe);
        await _recipeRepository.AddTags(request.Tags);
        await _unitOfWork.Save();
        await _recipeRepository.AddRecipeTags(recipe.Id, request.Tags);
        await _unitOfWork.Save();
        _logger.LogInformation("Recipe was created");
        return Ok();
    }

    [Route("addComment/{userId:int}/{recipeId:int}")]
    [HttpPost]
    public async Task<IActionResult> AddComment([FromRoute] int userId, int recipeId, [FromBody] CommentDto commentDto)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        Comment comment = _recipeDomainBuilder.CreateComment(commentDto, recipeId, userId);

        if (comment == null)
        {
            _logger.LogError("Failed to creating model");
            return BadRequest($"Can't create comment");
        }

        await _recipeRepository.AddComment(comment);
        await _unitOfWork.Save();

        return Ok(comment);

    }

    [Route("updateComment")]
    [HttpPost]
    public IActionResult UpdateComment([FromBody] CommentDto commentDto)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        Comment comment = _recipeDomainBuilder.CreateComment(commentDto);

        _recipeRepository.UpdateComment(comment);

        return Ok();
    }

    [Route("removeComment/{commentId:int}")]
    [HttpGet]
    public async Task<IActionResult> RemoveComment(int commentId)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        Comment comment = await _recipeRepository.GetCommentById(commentId);

        _recipeRepository.RemoveComment(comment);
        await _unitOfWork.Save();

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

    [Route("edit/{recipeId:int}")]
    [HttpPost]
    public async Task<IActionResult> EditRecipe([FromRoute] int recipeId, [FromForm] FullRecipeRequestDto request)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        string imgPath = await _imageService.AddImage(request.Img);
        Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
        recipe.Ingridients.Clear();
        recipe.Steps.Clear();
        recipe.RecipeTags.Clear();
        if (request.Ingridients == null || request.Steps == null)
        {
            return BadRequest();
        }
        _recipeUpdateBuilder.UpdateRecipe(recipe, request, imgPath);

        await _recipeRepository.AddTags(request.Tags);
        await _unitOfWork.Save();
        await _recipeRepository.AddRecipeTags(recipeId, request.Tags);

        IValidator<Recipe> recipeValidator = new RecipeValidator();
        recipeValidator.Validate(recipe);

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
        if (!isDeleted)
        {
            _logger.LogError("Failed to delete recipe");
            return BadRequest($"Can't delete recipe with id:{recipeId}");
        }

        await _unitOfWork.Save();
        _logger.LogInformation("Recipe deleted");
        return Ok();

    }

    [Route("allRecipes/{userId:int}/{filter:int}")]
    [HttpGet]
    public async Task<IActionResult> GetAllRecipes(int userId, int filter)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation("Getting all recipes...");
        List<Recipe> recipes = await _recipeRepository.GetAllRecipes((Filter)filter);
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

    [Route("favourites/{userId:int}/{filter:int}")]
    [HttpGet]
    public async Task<IActionResult> GetFavouritesRecipes(int userId, int filter)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation($"Getting favourites for user with id: {userId}");
        List<Recipe> recipes = await _recipeRepository.GetAllFavouritesRecipes(userId, (Filter)filter);
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

        _logger.LogInformation("Favourites successfully getted");
        return Ok(recipeDtos);

    }

    [Route("addFavourites/{userId:int}/{recipeId:int}")]
    [HttpGet]
    public async Task<IActionResult> AddToFavourites(int userId, int recipeId)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation($"Adding to user with id: {userId} favourites recipe with id: {recipeId}...");
        Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            _logger.LogWarning("Failed to add recipe to favourites");
            return BadRequest(
                $"Can't add recipe with id:{recipeId}" +
                $" to user favourites with id:{userId}"
            );
        }
        recipe.AddToFavourites(userId);
        await _unitOfWork.Save();
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
        if (!IsDeleted)
        {
            _logger.LogError("Failed to delete recipe from favourites");
            return BadRequest(
                $"Can't delete recipe with id:{recipeId}" +
                $" from user favourites with id:{userId}"
            );
        }

        await _unitOfWork.Save();
        _logger.LogInformation("Recipe successfully deleted from favourites");
        return Ok();

    }

    [Route("userRecipes/{userId:int}/{filter:int}")]
    [HttpGet]
    public async Task<IActionResult> GetUserRecipes(int userId, int filter)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation($"Getting recipes for user with id: {userId}");
        List<Recipe> recipes = await _recipeRepository.GetAllUsersRecipes(userId, (Filter)filter);
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

    [Route("search/{userId:int}/{filter:int}")]
    [HttpPost]
    public async Task<IActionResult> SearchRecipe([FromRoute] int userId, int filter, [FromBody] SearchRecipeModel searchRecipeModel)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation("Searching recipes...");
        List<Recipe> recipes = await _recipeRepository.SearchRecipes(searchRecipeModel.TagIds, searchRecipeModel.Name, (Filter)filter);

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

        _logger.LogInformation("Recipes found");
        return Ok(recipeDtos);

    }

    [Route("allTags")]
    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        List<Tag> tags = await _recipeRepository.GetAllTags();

        List<TagDto> tagDtos = tags.ConvertAll(t => new TagDto(t.Id, t.Name));

        return Ok(tagDtos);
    }

    [Route("addLike/{userId:int}/{recipeId:int}")]
    [HttpGet]
    public async Task<IActionResult> AddLike(int userId, int recipeId)
    {
        _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

        _logger.LogInformation($"Adding like to recipe with id: {recipeId} from user with id: {userId}");
        Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
        recipe.Like(userId);
        await _unitOfWork.Save();
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
        UserStats userStats = await _recipeRepository.GetUserStats(userId);

        return Ok(
            new
            {
                recipes = userStats.RecipesNumber,
                likes = userStats.Likes,
                favourites = userStats.FavouritesNumber,
                comments = userStats.CommentsNumber
            }
        );
    }

}

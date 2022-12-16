using recipe_api.Recipes.Mappers;
using recipe_api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_api;

public class RecipesDtoBuilder : IRecipesDtoBuilder
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IImageService _imageService;

    public RecipesDtoBuilder(
        IRecipeRepository recipeRepository,
        IImageService imageService,
        IUserRepository userRepository
        )
    {
        _recipeRepository = recipeRepository;
        _imageService = imageService;
        _userRepository = userRepository;
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
            List<Comment> comments = await _recipeRepository.GetAllRecipeComments(recipeId);
            bool isLike = await _recipeRepository.IsLikedForCurrentUser(userId, recipeId);
            List<Tag> tags = await _recipeRepository.GetRecipeTags(recipeId);
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                User user = await _userRepository.GetUser(comment.UserId);
                commentDtos.Add(new CommentDto()
                { Id = comment.Id, UserId = comment.UserId, Text = comment.Text, Time = comment.Time.ToString(), Author = user.Name }
                );
            }
            return new FullRecipeResponseDto
            (
                recipeId,
                img,
                recipe.Name,
                recipe.Description,
                recipe.Time,
                recipe.Persons,
                likes,
                commentDtos,
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
            int comments = await _recipeRepository.GetRecipeCommentsNumber(recipe.Id);
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
                comments,
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

    public async Task<CommentDto> CreateCommentDto(Comment comment)
    {
        if (comment == null)
        {
            return null;
        }

        User user = await _userRepository.GetUser(comment.UserId);
        string userName = user.Name;

        return new CommentDto()
        {
            UserId = comment.UserId,
            Author = userName,
            Text = comment.Text,
            Time = comment.Time.ToString()
        };
    }
}

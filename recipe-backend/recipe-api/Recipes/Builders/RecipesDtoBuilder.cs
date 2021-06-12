using Application;
using Microsoft.AspNetCore.Http;
using recipe_domain;
using System.IO;
using System.Threading.Tasks;

namespace recipe_api
{
	public class RecipesDtoBuilder : IRecipesDtoBuilder
	{
		private readonly IRecipeRepository _recipeRepository;

		public RecipesDtoBuilder(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public async Task<FullRecipeDto> CreateFullRecipeDto(int recipeId)
		{
			Recipe recipe = await _recipeRepository.GetRecipeById(recipeId);
			if (recipe != null)
			{
				return new FullRecipeDto
				(
					ConvertByteArrayToImage(recipe.Img),
					recipe.Name,
					recipe.Desc,
					recipe.Time,
					recipe.Persons,
					recipe.Likes,
					recipe.UserId,
					recipe.Tags.ConvertAll(
						t => new TagDto(t.Id, t.Name)),
					recipe.Ingridients.ConvertAll(
						i => new IngridientDto(i.Name, i.List)),
					recipe.Steps.ConvertAll(
						s => new StepDto(s.Name, s.Desc))
				);
			}
			return null;
		}

		public RecipeDto CreateRecipeDto(Recipe recipe)
		{
			if (recipe != null)
			{
				return new RecipeDto
				(
					recipe.Id,
					recipe.Img,
					recipe.Name,
					recipe.Desc,
					recipe.Time,
					recipe.Persons,
					recipe.Likes,
					recipe.UserId,
					recipe.Tags.ConvertAll(
						t => new TagDto(t.Id, t.Name))
				);
			}
			return null;
		}

		private IFormFile ConvertByteArrayToImage(byte[] img)
		{
			if (img.Length > 0)
			{
				using (var ms = new MemoryStream(img))
				{
					return new FormFile(ms, 0, img.Length, "name", "filename");
				}
			}
			return null;
		}
	}
}

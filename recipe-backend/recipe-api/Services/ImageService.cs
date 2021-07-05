using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using recipe_domain;
using System;
using System.IO;
using System.Threading.Tasks;

namespace recipe_api.Services
{
	public class ImageService : IImageService
	{
		private IRecipeRepository _recipeRepository;
		IWebHostEnvironment _appEnvironment;
		private const int MAX_IMAGE_SIZE = 2097152;

		public ImageService(
			IRecipeRepository recipeRepository,
			IWebHostEnvironment appEnvironment
			)
		{
			_recipeRepository = recipeRepository;
			_appEnvironment = appEnvironment;
		}

		public async Task<string> AddImage(IFormFile img)
		{
			if (img == null)
			{
				return null;
			}

			if (img.Length > MAX_IMAGE_SIZE)
			{
				throw new ArgumentOutOfRangeException("Превышение размера файла!");
			}

			string path = "/Images/" + img.FileName;

			if (await _recipeRepository.IsRepeatingImage(path))
			{
				return path;
			}

			using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
			{
				await img.CopyToAsync(fileStream);
			}

			return path;

		}

		public void DeleteImage(string path)
		{
			FileInfo img = new FileInfo(_appEnvironment.WebRootPath + path);

			if (!img.Exists)
			{
				throw new System.ArgumentNullException("Image doesn't exists!");
			}

			img.Delete();

			if (img.Exists)
			{
				throw new System.ArgumentException("Failed to delete image");
			}
		}

		public async Task<string> GetImage(string path)
		{
			if (path[0] != '/')
			{
				path = "/" + path;
			}
			using (FileStream fileStream = File.OpenRead(_appEnvironment.WebRootPath + path))
			{
				byte[] imgBytes = new byte[fileStream.Length];
				await fileStream.ReadAsync(imgBytes, 0, imgBytes.Length);
				
				return Convert.ToBase64String(imgBytes);
			}
		}
	}
}

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace recipe_api.Services;

public interface IImageService
{
	Task<string> AddImage(IFormFile img);

	void DeleteImage(string path);

	Task<string> GetImage(string path);
}

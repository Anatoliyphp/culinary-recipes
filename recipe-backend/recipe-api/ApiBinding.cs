using Microsoft.Extensions.DependencyInjection;
using recipe_api.Account.Builders;
using recipe_domain;
using recipe_infrastructure;

namespace recipe_api
{
	public static class ApiBinding
	{
		public static IServiceCollection AddApi(this IServiceCollection services)
		{
			return services
			.AddScoped<IUserRepository, UserRepository>()
			.AddScoped<IRecipeRepository, RecipeRepository>()
			.AddScoped<IUserDtoBuilder, UserDtoBuilder>()
			.AddScoped<IRecipesDtoBuilder, RecipesDtoBuilder>();
			
		}
	}
}

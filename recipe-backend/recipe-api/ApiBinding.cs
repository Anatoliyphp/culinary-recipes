using Microsoft.Extensions.DependencyInjection;
using recipe_api.Account.Builders;
using recipe_api.Recipes.Builders;
using recipe_api.Services;

namespace recipe_api;

public static class ApiBinding
{
    public static IServiceCollection AddApi(this IServiceCollection services, string key)
    {
        return services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IRecipeRepository, RecipeRepository>()
        .AddScoped<IUserDtoBuilder, UserDtoBuilder>()
        .AddScoped<IRecipesDtoBuilder, RecipesDtoBuilder>()
        .AddScoped<IImageService, ImageService>()
        .AddScoped<IHashService, HashService>(s => new HashService(key))
        .AddScoped<RecipeUpdateBuilder>();

    }
}

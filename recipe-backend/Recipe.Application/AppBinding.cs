using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class AppBinding
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			return services
				.AddScoped<IUserDomainBuilder, UserDomainBuilder>()
				.AddScoped<IRecipeDomainBuilder, RecipeDomainBuilder>();

		}
	}
}

using Microsoft.Extensions.DependencyInjection;
using recipe_infrastructure.UoW;
using System;

namespace recipe_infrastructure
{
	public static class InfrastructureBunding
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			return services
				.AddScoped<UnitOfWork>();

		}
	}
}

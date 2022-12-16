global using System;
global using recipe_api.Models;
global using recipe_infrastructure;
global using Application;
global using recipe_domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;

namespace recipe_api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<RecipesContext>(options => options.UseSqlServer(connection,	x => x.MigrationsAssembly("Recipe.Infrastructure.Migrations")).LogTo(Console.WriteLine, LogLevel.Information));

        services.AddControllers();

        services.AddApplication();

        services.AddInfrastructure();

        string securityKey = Configuration["SecurityKey"];
        services.AddApi(securityKey);

        var authOptionsConfiguration = Configuration.GetSection("Auth");
        services.Configure<AuthOptions>(authOptionsConfiguration);

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            );
        }
        );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        string path = Directory.GetCurrentDirectory();
        loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseDefaultFiles();

        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}

using Microsoft.EntityFrameworkCore;
using recipe_domain;
using recipe_infrastructure.Data.EntityConfigurations;

namespace recipe_infrastructure
{
    public class RecipesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }

        public RecipesContext(DbContextOptions<RecipesContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new IngridientMap());
            modelBuilder.ApplyConfiguration(new StepMap());
        }
    }
}
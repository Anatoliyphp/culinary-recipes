using Microsoft.EntityFrameworkCore;
using recipe_domain;
using recipe_infrastructure.comment.EntityConfiguration;
using recipe_infrastructure.Data.EntityConfigurations;
using recipe_infrastructure.Data.user.EntityConfigurations;

namespace recipe_infrastructure
{
    public class RecipesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<UserFavourites> UserFavourites { get; set; }
        public DbSet<RecipeLike> RecipeLikes { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public RecipesContext(DbContextOptions<RecipesContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new IngridientMap());
            modelBuilder.ApplyConfiguration(new StepMap());
            modelBuilder.ApplyConfiguration(new UserFavouriteMap());
            modelBuilder.ApplyConfiguration(new RecipeLikeMap());
            modelBuilder.ApplyConfiguration(new RecipeTagMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
        }
    }
}
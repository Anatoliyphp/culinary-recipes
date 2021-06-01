using Microsoft.EntityFrameworkCore;
using recipe_domain;


namespace recipe_api.Models{

    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
         public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
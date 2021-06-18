using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure
{
    public class RecipeLikeMap : IEntityTypeConfiguration<RecipeLike>
    {
		public void Configure(EntityTypeBuilder<RecipeLike> builder)
		{
			builder.HasKey(rl => new { rl.RecipeId, rl.UserId });

			builder.HasOne(rl => rl.User)
				.WithMany(u => u.RecipeLikes)
				.HasForeignKey(uf => uf.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(rl => rl.Recipe)
				.WithMany(r => r.RecipeLikes)
				.HasForeignKey(uf => uf.RecipeId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new RecipeLike(2, 2),
				new RecipeLike(2, 4),
				new RecipeLike(3, 1),
				new RecipeLike(3, 3)
				);
		}
	}
}

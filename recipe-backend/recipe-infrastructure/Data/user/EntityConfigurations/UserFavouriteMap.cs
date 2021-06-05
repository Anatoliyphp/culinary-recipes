using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.user.EntityConfigurations
{
	public class UserFavouriteMap : IEntityTypeConfiguration<UserFavourites>
	{
		public void Configure(EntityTypeBuilder<UserFavourites> builder)
		{
			builder.HasKey(f => new { f.RecipeId, f.UserId });

			builder.HasOne(uf => uf.User)
				.WithMany(u => u.UserFavourites)
				.HasForeignKey(uf => uf.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(uf => uf.Recipe)
				.WithMany(r => r.UserFavourites)
				.HasForeignKey(uf => uf.RecipeId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}

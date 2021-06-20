using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure
{
	class RecipeTagMap : IEntityTypeConfiguration<RecipeTag>
	{
		public void Configure(EntityTypeBuilder<RecipeTag> builder)
		{
			builder.HasKey(rt => new { rt.RecipeId, rt.TagId });

			builder.HasOne(rt => rt.Tag)
				.WithMany(t => t.RecipeTags)
				.HasForeignKey(rt => rt.TagId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(rl => rl.Recipe)
				.WithMany(r => r.RecipeTags)
				.HasForeignKey(rl => rl.RecipeId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new RecipeTag(1, 1),
				new RecipeTag(2, 2),
				new RecipeTag(3, 3),
				new RecipeTag(4, 4)
				);
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	class RecipeMap : IEntityTypeConfiguration<Recipe>
	{
		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.HasKey(r => r.RecipeId);

			builder.Property(r => r.RecipeId)
				.UseHiLo("DbSequenceHiLo");

			builder.Property(r => r.Name)
				.IsRequired()
				.HasMaxLength(30);

			builder.Property(r => r.Img).IsRequired();

			builder.Property(r => r.Desc)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(r => r.Time).IsRequired();

			builder.Property(r => r.Persons).IsRequired();

			builder.HasOne(r => r.User)
				.WithMany(u => u.Recipes)
				.HasForeignKey(r => r.UserId);
		}
	}
}

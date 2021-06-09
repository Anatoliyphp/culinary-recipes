using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	public class StepMap : IEntityTypeConfiguration<Step>
	{
		public void Configure(EntityTypeBuilder<Step> builder)
		{
			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id).UseHiLo("DbSequenceHiLo");

			builder.Property(s => s.Name)
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(s => s.Desc)
				.HasMaxLength(200)
				.IsRequired();

			builder.HasOne(s => s.Recipe)
				.WithMany(r => r.Steps)
				.HasForeignKey(s => s.RecipeId);
		}
	}
}

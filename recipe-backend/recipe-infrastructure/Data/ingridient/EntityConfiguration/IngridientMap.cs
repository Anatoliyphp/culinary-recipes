using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	public class IngridientMap : IEntityTypeConfiguration<Ingridient>
	{
		public void Configure(EntityTypeBuilder<Ingridient> builder)
		{
			builder.HasKey(i => i.IngridientId);

			builder.Property(i => i.IngridientId).UseHiLo("DbSequenceHiLo");

			builder.Property(i => i.Name)
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(i => i.List)
				.HasMaxLength(300)
				.IsRequired();
		}
	}
}

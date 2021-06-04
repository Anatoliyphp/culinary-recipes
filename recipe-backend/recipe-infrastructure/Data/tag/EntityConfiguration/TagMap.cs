using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	public class TagMap : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasKey(t => t.TagId);

			builder.Property(t => t.TagId).UseHiLo("DbSequenceHiLo");

			builder.Property(t => t.Name)
				.HasMaxLength(20)
				.IsRequired();
		}
	}
}

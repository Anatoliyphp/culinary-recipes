using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;
using System.Collections.Generic;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.UserId);

			builder.Property(u => u.UserId)
				.UseHiLo("DbSequenceHiLo");

			builder.Property(u => u.Name)
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(u => u.Login)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(u => u.Password)
				.HasMaxLength(50)
				.IsRequired();
		}
	}
}

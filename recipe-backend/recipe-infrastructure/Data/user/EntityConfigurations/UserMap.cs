using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);

			builder.Property(u => u.Id)
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

			builder.HasData
				(
					new User(
							login: "vasya",
							password: "abcd",
							name: "Василий"
					)
					{ Id = 2, About = "" },
					new User(
							login: "artem228",
							password: "bezymno mozno bit pervim",
							name: "Боевик"
						)
					{
						Id = 3,
						About = "На маму не кричи, она не виновата, что у тебя не все как надо…"
					}
				);
		}
	}
}

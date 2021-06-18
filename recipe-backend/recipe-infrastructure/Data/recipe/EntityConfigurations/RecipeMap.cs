using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	class RecipeMap : IEntityTypeConfiguration<Recipe>
	{
		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.HasKey(r => r.Id);

			builder.Property(r => r.Id)
				.UseHiLo("DbSequenceHiLo");

			builder.Property(r => r.Name)
				.IsRequired()
				.HasMaxLength(30);

			builder.Property(r => r.Img).IsRequired();

			builder.Property(r => r.Description)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(r => r.Time).IsRequired();

			builder.Property(r => r.Persons).IsRequired();

			builder.HasOne(r => r.User)
				.WithMany(u => u.Recipes)
				.HasForeignKey(r => r.UserId);

			builder.HasData(
				new Recipe(
						img: "/Images/FirstRecipe.png",
						name: "Клубничная панна-котта",
						description:
							"Десерт, который невероятно легко и быстро готовится." +
							" Советую подавать его порционно в красивых бокалах," +
							" украсив взбитыми сливками, свежими ягодами и мятой.",
						time: 35,
						persons: 5,
						userId: 2
					)
				{ Id = 1 },

				new Recipe(
						img: "/Images/SecondRecipe.png",
						name: "Мясные фрикадельки",
						description:
							"Мясные фрикадельки в томатном соусе - " +
							"несложное и вкусное блюдо, которым можно" +
							" порадовать своих близких. ",
						time: 90,
						persons: 4,
						userId: 3
					)
				{ Id = 2 },

				new Recipe(
						img: "Images/ThirdRecipe.png",
						name: "Панкейки",
						description:
						"Панкейки: меньше, чем блины, но больше, чем оладьи." +
						" Основное отличие — в тесте, оно должно быть воздушным," +
						" чтобы панкейки не растекались по сковородке...",
						time: 40,
						persons: 3,
						userId: 2
					)
				{ Id = 3 },

				new Recipe(
						img: "Images/FouthRecipe.png",
						name: "Полезное мороженое без сахара",
						description:
						"Йогуртовое мороженое сочетает в себе нежный вкус и " +
						"низкую калорийность, что будет особенно актуально" +
						" для сладкоежек, соблюдающих диету.",
						time: 35,
						persons: 2,
						userId: 3
					)
				{ Id = 4 }
				);
		}
	}
}

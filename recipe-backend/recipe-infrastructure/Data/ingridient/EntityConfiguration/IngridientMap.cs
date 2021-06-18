using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_domain;

namespace recipe_infrastructure.Data.EntityConfigurations
{
	public class IngridientMap : IEntityTypeConfiguration<Ingridient>
	{
		public void Configure(EntityTypeBuilder<Ingridient> builder)
		{
			builder.HasKey(i => i.Id);

			builder.Property(i => i.Id).UseHiLo("DbSequenceHiLo");

			builder.Property(i => i.Name)
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(i => i.List)
				.HasMaxLength(300)
				.IsRequired();

			builder.HasOne(i => i.Recipe)
				.WithMany(r => r.Ingridients)
				.HasForeignKey(i => i.RecipeId);

			builder.HasData(
					new Ingridient(
						name: "Для панна конты",
						list:
							"Сливки-20-30% - 500мл." +
							"Молоко - 100мл." +
							"Желатин - 2ч.л." +
							"Сахар - 3ст.л." +
							"Ванильный сахар - 2 ч.л.",
						recipeId: 1
						){ Id = 1 },
					new Ingridient(
						name: "Для фрикаделек",
						list:
							"Фарш мясной - 500г."+
							"Соль - 2ст. ложки"+
							"Хлеб пшеничный - 200г.",
						recipeId: 2
						){ Id = 2 },
					new Ingridient(
						name: "Для панкейков",
						list:
							"Яйца - 2 шт."+
							"Молоко - 200 мл" +
							"Мука пшеничная - 10 ст.л." +
							"Разрыхлитель - 1 ч.л." +
							"Сахар - 2 ст.л.",
						recipeId: 3
						) { Id = 3},
					new Ingridient(
						name: "Для мороженого",
						list:
							"200 г сливок для взбивания" +
							"100 г сгущённого молока.",
						recipeId: 4
						){ Id = 4 }
				);
		}
	}
}

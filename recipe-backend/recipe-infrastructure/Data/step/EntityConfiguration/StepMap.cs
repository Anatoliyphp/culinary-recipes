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

			builder.HasData(
					new Step(
							name: "Шаг 1",
							desc:
								"Приготовим панна котту: Зальем желатин молоком" +
								" и поставим на 30 минут для набухания." +
								" В сливки добавим сахар и ванильный сахар." +
								" Доводим до кипения (не кипятим!).",
							recipeId: 1
						)
					{ Id = 1 },
					new Step(
							name: "Шаг 2",
							desc:
								"Добавим в сливки набухший в молоке желатин." +
								" Перемешаем до полного растворения." +
								" Огонь отключаем. Охладим до комнатной температуры.",
							recipeId: 1
						)
					{ Id = 2 },
					new Step(
							name: "Шаг 1",
							desc:
								"Для приготовления фрикаделек к фаршу добавьте яйцо" +
								" и измельченную зелень. По вкусу посыпьте небольшим" +
								" количеством соли и специи. Все хорошо перемешайте" +
								" до однородной массы.",
							recipeId: 2
						)
					{ Id = 3 },
					new Step(
							name: "Шаг 1",
							desc:
								"Смешайте 2 яйца и 200 мл молока." +
								"Затем добавьте 2 ст.л.сахара и ваниль.Взбейте до однородности." +
								"Добавьте 10 ст.л.муки и разрыхлитель.Тщательно перемешайте." +
								"Тесто получится средней густоты.",
							recipeId: 3
						)
					{ Id = 4 },
					new Step(
							name: "Шаг 1",
							desc:
								"Взбейте миксером холодные сливки до кремообразной консистенции." +
								" Затем смешайте их со сгущёнкой.",
							recipeId: 4
						)
					{ Id = 5 }
				);
		}
	}
}

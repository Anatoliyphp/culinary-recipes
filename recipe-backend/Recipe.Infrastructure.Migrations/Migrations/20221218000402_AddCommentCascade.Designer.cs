﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using recipe_infrastructure;

namespace Migrations
{
    [DbContext(typeof(RecipesContext))]
    [Migration("20221218000402_AddCommentCascade")]
    partial class AddCommentCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence("DbSequenceHiLo")
                .IncrementsBy(10);

            modelBuilder.Entity("recipe_domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("recipe_domain.Ingridient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("List")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingridients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            List = "Сливки-20-30% - 500мл.Молоко - 100мл.Желатин - 2ч.л.Сахар - 3ст.л.Ванильный сахар - 2 ч.л.",
                            Name = "Для панна конты",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            List = "Фарш мясной - 500г.Соль - 2ст. ложкиХлеб пшеничный - 200г.",
                            Name = "Для фрикаделек",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 3,
                            List = "Яйца - 2 шт.Молоко - 200 млМука пшеничная - 10 ст.л.Разрыхлитель - 1 ч.л.Сахар - 2 ст.л.",
                            Name = "Для панкейков",
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 4,
                            List = "200 г сливок для взбивания100 г сгущённого молока.",
                            Name = "Для мороженого",
                            RecipeId = 4
                        });
                });

            modelBuilder.Entity("recipe_domain.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Persons")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.",
                            Img = "/Images/FirstRecipe.png",
                            Name = "Клубничная панна-котта",
                            Persons = 5,
                            Time = 35,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких. ",
                            Img = "/Images/SecondRecipe.png",
                            Name = "Мясные фрикадельки",
                            Persons = 4,
                            Time = 90,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Панкейки: меньше, чем блины, но больше, чем оладьи. Основное отличие — в тесте, оно должно быть воздушным, чтобы панкейки не растекались по сковородке...",
                            Img = "Images/ThirdRecipe.png",
                            Name = "Панкейки",
                            Persons = 3,
                            Time = 40,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Йогуртовое мороженое сочетает в себе нежный вкус и низкую калорийность, что будет особенно актуально для сладкоежек, соблюдающих диету.",
                            Img = "Images/FouthRecipe.png",
                            Name = "Полезное мороженое без сахара",
                            Persons = 2,
                            Time = 35,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("recipe_domain.RecipeLike", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipeLikes");

                    b.HasData(
                        new
                        {
                            RecipeId = 2,
                            UserId = 2,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 4,
                            UserId = 2,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 1,
                            UserId = 3,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 3,
                            UserId = 3,
                            Id = 0
                        });
                });

            modelBuilder.Entity("recipe_domain.RecipeTag", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipeTags");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            TagId = 1,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 2,
                            TagId = 2,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 3,
                            TagId = 3,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 4,
                            TagId = 4,
                            Id = 0
                        });
                });

            modelBuilder.Entity("recipe_domain.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).",
                            Name = "Шаг 1",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.",
                            Name = "Шаг 2",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Для приготовления фрикаделек к фаршу добавьте яйцо и измельченную зелень. По вкусу посыпьте небольшим количеством соли и специи. Все хорошо перемешайте до однородной массы.",
                            Name = "Шаг 1",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Desc = "Смешайте 2 яйца и 200 мл молока.Затем добавьте 2 ст.л.сахара и ваниль.Взбейте до однородности.Добавьте 10 ст.л.муки и разрыхлитель.Тщательно перемешайте.Тесто получится средней густоты.",
                            Name = "Шаг 1",
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 5,
                            Desc = "Взбейте миксером холодные сливки до кремообразной консистенции. Затем смешайте их со сгущёнкой.",
                            Name = "Шаг 1",
                            RecipeId = 4
                        });
                });

            modelBuilder.Entity("recipe_domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "клубника"
                        },
                        new
                        {
                            Id = 2,
                            Name = "сладости"
                        },
                        new
                        {
                            Id = 3,
                            Name = "мясо"
                        },
                        new
                        {
                            Id = 4,
                            Name = "мороженое"
                        });
                });

            modelBuilder.Entity("recipe_domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DbSequenceHiLo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("About")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            About = "",
                            Login = "vasya",
                            Name = "Василий",
                            Password = "abcd"
                        },
                        new
                        {
                            Id = 3,
                            About = "На маму не кричи, она не виновата, что у тебя не все как надо…",
                            Login = "artem228",
                            Name = "Боевик",
                            Password = "bezymno mozno bit pervim"
                        });
                });

            modelBuilder.Entity("recipe_domain.UserFavourites", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavourites");

                    b.HasData(
                        new
                        {
                            RecipeId = 2,
                            UserId = 2,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 4,
                            UserId = 2,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 1,
                            UserId = 3,
                            Id = 0
                        },
                        new
                        {
                            RecipeId = 3,
                            UserId = 3,
                            Id = 0
                        });
                });

            modelBuilder.Entity("recipe_domain.Comment", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("recipe_domain.Ingridient", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("Ingridients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("recipe_domain.Recipe", b =>
                {
                    b.HasOne("recipe_domain.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("recipe_domain.RecipeLike", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("RecipeLikes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_domain.User", "User")
                        .WithMany("RecipeLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("recipe_domain.RecipeTag", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("RecipeTags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_domain.Tag", "Tag")
                        .WithMany("RecipeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("recipe_domain.Step", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("recipe_domain.UserFavourites", b =>
                {
                    b.HasOne("recipe_domain.Recipe", "Recipe")
                        .WithMany("UserFavourites")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_domain.User", "User")
                        .WithMany("UserFavourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("recipe_domain.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ingridients");

                    b.Navigation("RecipeLikes");

                    b.Navigation("RecipeTags");

                    b.Navigation("Steps");

                    b.Navigation("UserFavourites");
                });

            modelBuilder.Entity("recipe_domain.Tag", b =>
                {
                    b.Navigation("RecipeTags");
                });

            modelBuilder.Entity("recipe_domain.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("RecipeLikes");

                    b.Navigation("Recipes");

                    b.Navigation("UserFavourites");
                });
#pragma warning restore 612, 618
        }
    }
}

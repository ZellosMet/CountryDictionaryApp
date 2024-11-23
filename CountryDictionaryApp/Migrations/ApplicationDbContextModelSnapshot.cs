﻿// <auto-generated />
using CountryDictionaryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountryDictionaryApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CountryDictionaryApp.Entity.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ISO31661Alpha2Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISO31661Alpha3Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISO31661NumericCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ISO31661Alpha2Code = "ru",
                            ISO31661Alpha3Code = "rus",
                            ISO31661NumericCode = "643",
                            Name = "Россия"
                        },
                        new
                        {
                            Id = 2,
                            ISO31661Alpha2Code = "us",
                            ISO31661Alpha3Code = "usa",
                            ISO31661NumericCode = "840",
                            Name = "Соединённые Штаты Америки"
                        },
                        new
                        {
                            Id = 3,
                            ISO31661Alpha2Code = "cn",
                            ISO31661Alpha3Code = "chn",
                            ISO31661NumericCode = "156",
                            Name = "Китай"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

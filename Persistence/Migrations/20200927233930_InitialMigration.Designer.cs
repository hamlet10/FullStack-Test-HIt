﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Persistence;

namespace UrlShortener.Persistence.Migrations
{
    [DbContext(typeof(UrlShortenerDbContext))]
    [Migration("20200927233930_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlShortener.Entities.MyUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyUrls");
                });

            modelBuilder.Entity("UrlShortener.Entities.Visitors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrowserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyUrlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MyUrlId")
                        .IsUnique();

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("UrlShortener.Entities.Visitors", b =>
                {
                    b.HasOne("UrlShortener.Entities.MyUrl", "MyUrl")
                        .WithOne("Visitors")
                        .HasForeignKey("UrlShortener.Entities.Visitors", "MyUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
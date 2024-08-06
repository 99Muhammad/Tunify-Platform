﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify.Data;

#nullable disable

namespace Tunify.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240806115016_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify.Model.Albums", b =>
                {
                    b.Property<int>("AlbumsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumsID"));

                    b.Property<string>("AlbumsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("AlbumsName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.HasKey("AlbumsID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Tunify.Model.Artists", b =>
                {
                    b.Property<int>("ArtistsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistsID"));

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ArtistName");

                    b.Property<string>("Bio")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Bio");

                    b.HasKey("ArtistsID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Tunify.Model.PlayList", b =>
                {
                    b.Property<int>("PlayListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayListID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PlayListName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PlayListName");

                    b.HasKey("PlayListID");

                    b.ToTable("PlayList");

                    b.HasData(
                        new
                        {
                            PlayListID = 1,
                            CreatedDate = new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayListName = "HowYourLife"
                        },
                        new
                        {
                            PlayListID = 2,
                            CreatedDate = new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayListName = "FunG"
                        });
                });

            modelBuilder.Entity("Tunify.Model.PlayListSong", b =>
                {
                    b.Property<int>("PlayListSongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayListSongID"));

                    b.HasKey("PlayListSongID");

                    b.ToTable("PlayListSong");
                });

            modelBuilder.Entity("Tunify.Model.Songs", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongID"));

                    b.Property<TimeSpan>("Durtion")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Genre");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Title");

                    b.HasKey("SongID");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongID = 1,
                            Durtion = new TimeSpan(0, 0, 0, 0, 0),
                            Genre = "johndoe@example.com",
                            Title = "JohnDoe"
                        },
                        new
                        {
                            SongID = 2,
                            Durtion = new TimeSpan(0, 0, 0, 0, 0),
                            Genre = "Mark@example.com",
                            Title = "Mark"
                        });
                });

            modelBuilder.Entity("Tunify.Model.Subscription", b =>
                {
                    b.Property<int>("SubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SubscriptionType");

                    b.HasKey("SubscriptionID");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("Tunify.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Email")
                        .HasAnnotation("RegularExpression", "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "johndoe@example.com",
                            Join_Date = new DateTime(2010, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "JohnDoe"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "Mark@example.com",
                            Join_Date = new DateTime(2013, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Mark"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

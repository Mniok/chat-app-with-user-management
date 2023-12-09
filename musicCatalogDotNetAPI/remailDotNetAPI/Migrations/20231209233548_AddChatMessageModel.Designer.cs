﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using musicCatalogDotNetAPI.Services;

#nullable disable

namespace musicCatalogDotNetAPI.Migrations
{
    [DbContext(typeof(DBService))]
    [Migration("20231209233548_AddChatMessageModel")]
    partial class AddChatMessageModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArtistId");

                    b.HasIndex("SongId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimePosted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WasEdited")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WasRemoved")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenreId");

                    b.HasIndex("SongId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkBody")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToSite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LinkId");

                    b.HasIndex("SongId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SongId");

                    b.HasIndex("UserId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BannedUntil")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MutedUntil")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OriginalUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserRole")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedAt = new DateTime(2023, 12, 10, 0, 35, 47, 745, DateTimeKind.Local).AddTicks(3579),
                            OriginalUserName = "testuser1",
                            Password = "testpass1",
                            UserName = "testuser1",
                            UserRole = "BasicUser"
                        },
                        new
                        {
                            UserId = 2,
                            CreatedAt = new DateTime(2023, 12, 10, 0, 35, 47, 745, DateTimeKind.Local).AddTicks(3632),
                            OriginalUserName = "testuser2",
                            Password = "testpass2",
                            UserName = "testuser2",
                            UserRole = "BasicUser"
                        });
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Artist", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.Song", "Song")
                        .WithMany("Artists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.ChatMessage", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.User", "UploadedBy")
                        .WithMany("postedMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UploadedBy");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Genre", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.Song", "Song")
                        .WithMany("Genres")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Link", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.Song", "Song")
                        .WithMany("Links")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Song", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.User", "UploadedBy")
                        .WithMany("uploadedSongs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UploadedBy");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.Song", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Genres");

                    b.Navigation("Links");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.User", b =>
                {
                    b.Navigation("postedMessages");

                    b.Navigation("uploadedSongs");
                });
#pragma warning restore 612, 618
        }
    }
}
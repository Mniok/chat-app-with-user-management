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
    [Migration("20221013152008_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.MasterEmail", b =>
                {
                    b.Property<int>("MasterEmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasterEmailId");

                    b.HasIndex("UserId");

                    b.ToTable("MasterEmail");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.SubEmail", b =>
                {
                    b.Property<int>("SubEmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MasterEmailId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubEmailId");

                    b.HasIndex("MasterEmailId");

                    b.ToTable("SubEmail");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

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
                            CreatedAt = new DateTime(2022, 10, 13, 17, 20, 8, 414, DateTimeKind.Local).AddTicks(1208),
                            OriginalUserName = "testuser1",
                            Password = "testpass1",
                            UserName = "testuser1",
                            UserRole = "BasicUser"
                        },
                        new
                        {
                            UserId = 2,
                            CreatedAt = new DateTime(2022, 10, 13, 17, 20, 8, 414, DateTimeKind.Local).AddTicks(1241),
                            OriginalUserName = "testuser2",
                            Password = "testpass2",
                            UserName = "testuser2",
                            UserRole = "BasicUser"
                        });
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.MasterEmail", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.User", "User")
                        .WithMany("masterEmails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.SubEmail", b =>
                {
                    b.HasOne("musicCatalogDotNetAPI.Models.MasterEmail", "MasterEmail")
                        .WithMany("subEmails")
                        .HasForeignKey("MasterEmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterEmail");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.MasterEmail", b =>
                {
                    b.Navigation("subEmails");
                });

            modelBuilder.Entity("musicCatalogDotNetAPI.Models.User", b =>
                {
                    b.Navigation("masterEmails");
                });
#pragma warning restore 612, 618
        }
    }
}

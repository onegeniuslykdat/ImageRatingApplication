﻿// <auto-generated />
using System;
using ImageRatingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageRatingAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImageRatingAPI.Data.ImageEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImageSourceEntityID")
                        .HasColumnType("int");

                    b.Property<string>("NameWithExt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourcePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ImageSourceEntityID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.ImageSourceEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ImageSources");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.UserEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.UserImageRatingEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImageID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("UserID");

                    b.ToTable("UserImageRatings");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.ImageEntity", b =>
                {
                    b.HasOne("ImageRatingAPI.Data.ImageSourceEntity", "ImageSource")
                        .WithMany("Images")
                        .HasForeignKey("ImageSourceEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageSource");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.UserImageRatingEntity", b =>
                {
                    b.HasOne("ImageRatingAPI.Data.ImageEntity", "Image")
                        .WithMany("ImageRatings")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageRatingAPI.Data.UserEntity", "User")
                        .WithMany("ImageRatings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.ImageEntity", b =>
                {
                    b.Navigation("ImageRatings");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.ImageSourceEntity", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ImageRatingAPI.Data.UserEntity", b =>
                {
                    b.Navigation("ImageRatings");
                });
#pragma warning restore 612, 618
        }
    }
}

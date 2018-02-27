﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MusicChart.Data;
using System;

namespace MusicChart.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicChart.Models.Album", b =>
                {
                    b.Property<string>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageId");

                    b.Property<string>("Name");

                    b.Property<string>("SingerId");

                    b.HasKey("AlbumId");

                    b.HasIndex("ImageId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicChart.Models.Image", b =>
                {
                    b.Property<string>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source");

                    b.HasKey("ImageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MusicChart.Models.SimiliarMap", b =>
                {
                    b.Property<string>("SimiliarMapId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SimiliarSingerId");

                    b.Property<string>("SingerId");

                    b.HasKey("SimiliarMapId");

                    b.ToTable("SimiliarMaps");
                });

            modelBuilder.Entity("MusicChart.Models.Singer", b =>
                {
                    b.Property<string>("SingerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageId");

                    b.Property<int>("IsTop");

                    b.Property<string>("Name");

                    b.HasKey("SingerId");

                    b.HasIndex("ImageId");

                    b.ToTable("Singers");
                });

            modelBuilder.Entity("MusicChart.Models.Song", b =>
                {
                    b.Property<string>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("SingerId");

                    b.HasKey("SongId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicChart.Models.Album", b =>
                {
                    b.HasOne("MusicChart.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("MusicChart.Models.Singer", b =>
                {
                    b.HasOne("MusicChart.Models.Image", "Photo")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });
#pragma warning restore 612, 618
        }
    }
}

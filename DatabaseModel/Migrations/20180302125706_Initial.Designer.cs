﻿// <auto-generated />
using DatabaseModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DatabaseModel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180302125706_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuisnessModel.Models.Album", b =>
                {
                    b.Property<string>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageId");

                    b.Property<string>("Name");

                    b.Property<string>("SingerId");

                    b.HasKey("AlbumId");

                    b.HasIndex("ImageId");

                    b.HasIndex("SingerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("BuisnessModel.Models.Image", b =>
                {
                    b.Property<string>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source");

                    b.HasKey("ImageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BuisnessModel.Models.SimiliarMap", b =>
                {
                    b.Property<string>("SimiliarMapId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SimiliarSingerId");

                    b.Property<string>("SingerId");

                    b.HasKey("SimiliarMapId");

                    b.ToTable("SimiliarMaps");
                });

            modelBuilder.Entity("BuisnessModel.Models.Singer", b =>
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

            modelBuilder.Entity("BuisnessModel.Models.Song", b =>
                {
                    b.Property<string>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumId");

                    b.Property<string>("AlbumName");

                    b.Property<string>("Name");

                    b.Property<string>("SingerId");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("SingerId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("BuisnessModel.Models.Album", b =>
                {
                    b.HasOne("BuisnessModel.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("BuisnessModel.Models.Singer")
                        .WithMany("Albums")
                        .HasForeignKey("SingerId");
                });

            modelBuilder.Entity("BuisnessModel.Models.Singer", b =>
                {
                    b.HasOne("BuisnessModel.Models.Image", "Photo")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("BuisnessModel.Models.Song", b =>
                {
                    b.HasOne("BuisnessModel.Models.Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.HasOne("BuisnessModel.Models.Singer")
                        .WithMany("Songs")
                        .HasForeignKey("SingerId");
                });
#pragma warning restore 612, 618
        }
    }
}

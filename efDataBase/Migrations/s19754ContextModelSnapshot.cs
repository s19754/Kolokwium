﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efDataBase.Models;

namespace efDataBase.Migrations
{
    [DbContext(typeof(s19754Context))]
    partial class s19754ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Nerwosol",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "LekNaWszystko",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("efDataBase.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "cos"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "cos2"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Tomasz",
                            LastName = "Kołowski",
                            NickName = "Koło"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Michał",
                            LastName = "Michalski",
                            NickName = "Miszka"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musician_Tracks");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 2
                        },
                        new
                        {
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasMaxLength(60)
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 1.9f,
                            IdMusicAlbum = 1,
                            TrackName = "name1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 1.5f,
                            IdMusicAlbum = 2,
                            TrackName = "name2"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.HasOne("efDataBase.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("efDataBase.Models.Musician_Track", b =>
                {
                    b.HasOne("efDataBase.Models.Musician", "Musicians")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("efDataBase.Models.Track", "Tracks")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musicians");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.HasOne("efDataBase.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("efDataBase.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("efDataBase.Models.Musician", b =>
                {
                    b.Navigation("Musician_Tracks");
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.Navigation("Musician_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}

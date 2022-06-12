using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Models
{
    public class s19754Context : DbContext
    {

        protected s19754Context()
        {

        }
            

        public s19754Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(p =>
            {

                p.HasKey(e => e.IdMusician);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                p.Property(e => e.NickName).HasMaxLength(20);
                
                p.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Tomasz",
                        LastName = "Kołowski",
                        NickName = "Koło", 
                       
                    },
                    new Musician
                    {
                        IdMusician = 2,
                        FirstName = "Michał",
                        LastName = "Michalski",
                        NickName = "Miszka",

                    }
                    );
                
            });

            modelBuilder.Entity<Track>(d =>
            {
                d.HasKey(e => e.IdTrack);
                d.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                d.Property(e => e.Duration).IsRequired().HasMaxLength(60);
                d.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);
                
                d.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "name1",
                        Duration = 1.9f,
                        IdMusicAlbum = 1

                    },
                    new Track
                    {
                        IdTrack = 2,
                        TrackName = "name2",
                        Duration = 1.5f,
                        IdMusicAlbum = 2,
                    }
                    );
                
            });
                

                modelBuilder.Entity<MusicLabel>(p =>
            {
                p.HasKey(e => e.IdMusicLabel);
                p.Property(e => e.Name).HasMaxLength(50);


                
                p.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "cos"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 2,
                        Name = "cos2"
                    }
                    );
                
            });
                

                modelBuilder.Entity<Album>(m =>
            {
                m.HasKey(e => e.IdAlbum);
                m.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                m.Property(e => e.PublishDate).IsRequired();
                m.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);
                
                m.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Nerwosol",
                        PublishDate = DateTime.Parse("2022-04-18"),
                        IdMusicLabel = 1
                    },
                    new Album
                    {
                        IdAlbum = 2,
                        AlbumName = "LekNaWszystko",
                        PublishDate = DateTime.Parse("2022-04-18"),
                        IdMusicLabel = 2
                    }
                    );
                
            });

            modelBuilder.Entity<Musician_Track>(p =>
            {
                p.HasKey(e => new { e.IdMusician, e.IdTrack });
                p.HasOne(e => e.Musicians).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                p.HasOne(e => e.Tracks).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                
                p.HasData(
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1
                        
                    },
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 2
                        
                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 2
                        
                    }

                    );
                
            });
                
            }
                

            }
}

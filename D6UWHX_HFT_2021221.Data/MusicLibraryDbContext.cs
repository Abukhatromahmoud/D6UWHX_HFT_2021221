using D6UWHX_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Data
{


    public class MusicLibraryDbContext : DbContext
    {
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }
        public MusicLibraryDbContext()
        {
            
        }
        public MusicLibraryDbContext(DbContextOptions <MusicLibraryDbContext> options ) : base (options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@" Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Track>().ToTable("Track");
            

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(Album => Album.Artist)
                    .WithMany(Artist => Artist.Albums)
                    .HasForeignKey(Artist => Artist.AlbumID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasOne(Track => Track.Artist)
                    .WithMany(Artist => Artist.Tracks)
                    .HasForeignKey(Artist => Artist.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            }); modelBuilder.Entity<Track>(entity =>
            {
                entity.HasOne(Track => Track.Album)
                    .WithMany(Album => Album.Tracks)
                    .HasForeignKey(Album => Album.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Track>().ToTable("Track");


            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(Album => Album.Artist)
                    .WithMany(Artist => Artist.Albums)
                    .HasForeignKey(Artist => Artist.AlbumID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasOne(Track => Track.Artist)
                    .WithMany(Artist => Artist.Tracks)
                    .HasForeignKey(Artist => Artist.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            }); modelBuilder.Entity<Track>(entity =>
            {
                entity.HasOne(Track => Track.Album)
                    .WithMany(Album => Album.Tracks)
                    .HasForeignKey(Album => Album.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Album>().HasData(new Album { AlbumID = 1, Title = "Mike " },
            new Album { AlbumID = 2, Title = "Mte " },
            new Album { AlbumID = 3, Title = "Adem " },
            new Album { AlbumID = 4, Title = "Mase " },
            new Album { AlbumID = 5, Title = "Roni " },
            new Album { AlbumID = 6, Title = "safer " },
            new Album { AlbumID = 7, Title = "milan" },
            new Album { AlbumID = 8, Title = "rose" },
            new Album { AlbumID = 9, Title = "adreian " },
            new Album { AlbumID = 10, Title = "Sam " });
            modelBuilder.Entity<Track>().HasData(new Track { TrackId = 1, NamePlace = "Budapest", Length = 1 },
            new Track { TrackId = 2, NamePlace = "cairo", Length = 1 },
            new Track { TrackId = 3, NamePlace = "cdc", Length = 1 },
            new Track { TrackId = 4, NamePlace = "mlf", Length = 1 },
            new Track { TrackId = 5, NamePlace = "ded", Length = 1 },
            new Track { TrackId = 6, NamePlace = "mlm", Length = 1 },
            new Track { TrackId = 7, NamePlace = "qre", Length = 1 },
            new Track { TrackId = 8, NamePlace = "sad", Length = 1 },
            new Track { TrackId = 9, NamePlace = "li", Length = 1 },
            new Track { TrackId = 10, NamePlace = "egr", Length = 1 },
            new Track { TrackId = 11, NamePlace = "degf", Length = 1 },
            new Track { TrackId = 12, NamePlace = "Qwe", Length = 1 });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 1, Name = "Maoh ", Age = 15, AlbumID = 2 },
            new Artist { ArtistId = 2, Name = "mhm ", Age = 15, AlbumID = 3 },
            new Artist { ArtistId = 3, Name = "mrm ", Age = 15, AlbumID = 4 },
            new Artist { ArtistId = 4, Name = "vdsg ", Age = 15, AlbumID = 5 },
            new Artist { ArtistId = 5, Name = "Asfds ", Age = 15, AlbumID = 6 },
            new Artist { ArtistId = 6, Name = "fdesfs ", Age = 15, AlbumID = 7 },
            new Artist { ArtistId = 7, Name = "efeswgf ", Age = 15, AlbumID = 8 },
            new Artist { ArtistId = 8, Name = "fdasfds ", Age = 15, AlbumID = 9 },
            new Artist { ArtistId = 9, Name = "fdsgf ", Age = 15, AlbumID = 10 },
            new Artist { ArtistId = 10, Name = "drtfeg ", Age = 15, AlbumID = 11 },
            new Artist { ArtistId = 11, Name = "fewsfew ", Age = 15, AlbumID = 12 });



        }

    }
}

using D6UWHX_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Data
{


    public class MusicLibraryContext : DbContext
    {
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }
        public MusicLibraryContext()
        {
            
        }
        public MusicLibraryContext(DbContextOptions <MusicLibraryContext> options ) : base (options)
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
            new Album { AlbumID = 2, Title = "Title 1" },
            new Album { AlbumID = 3, Title = "Title 2 " },
            new Album { AlbumID = 4, Title = "Title 3  " },
            new Album { AlbumID = 5, Title = "Title 4  " },
            new Album { AlbumID = 6, Title = "Title 5 " },
            new Album { AlbumID = 7, Title = "Title 6 " },
            new Album { AlbumID = 8, Title = "Title 7 " },
            new Album { AlbumID = 9, Title = "Title 8 " },
            new Album { AlbumID = 10, Title = "Title 10 " });
            modelBuilder.Entity<Track>().HasData(new Track { TrackId = 1, NamePlace = "ballads", Length = 10 },
            new Track { TrackId = 2, NamePlace = "novelty songs", Length = 15 },
            new Track { TrackId = 3, NamePlace = "anthems", Length = 20},
            new Track { TrackId = 4, NamePlace = "rock", Length = 30 },
            new Track { TrackId = 5, NamePlace = "blues", Length = 40 },
            new Track { TrackId = 6, NamePlace = "life", Length = 50 },
            new Track { TrackId = 7, NamePlace = "soul songs", Length = 60 },
            new Track { TrackId = 8, NamePlace = "Pop ", Length = 70 },
            new Track { TrackId = 9, NamePlace = " Classical", Length = 80 },
            new Track { TrackId = 10, NamePlace = "Hip-Hop and Rap", Length = 75 },
            new Track { TrackId = 11, NamePlace = "EDM (Electronic Dance Music)", Length =60},
            new Track { TrackId = 12, NamePlace = "Metal", Length = 55 });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 1, Name = "David  ", Age = 40, AlbumID = 1 },
            new Artist { ArtistId = 2, Name = "James ", Age = 33, AlbumID = 2 },
            new Artist { ArtistId = 3, Name = "Demi  ", Age = 23, AlbumID = 3 },
            new Artist { ArtistId = 4, Name = "Diana  ", Age = 40, AlbumID = 4 },
            new Artist { ArtistId = 5, Name = "Eminem ", Age = 25, AlbumID = 5 },
            new Artist { ArtistId = 6, Name = "Eve ", Age = 40, AlbumID = 6},
            new Artist { ArtistId = 7, Name = "Johnny  ", Age = 27, AlbumID = 7},
            new Artist { ArtistId = 8, Name = "Mate ", Age = 17, AlbumID = 8},
            new Artist { ArtistId = 9, Name = " Bill ", Age = 57, AlbumID = 9 },
            new Artist { ArtistId = 10, Name = "Foxy ", Age = 60, AlbumID = 10 },
            new Artist { ArtistId = 11, Name = "Rex ", Age = 33, AlbumID = 11 });



        }

    }
}

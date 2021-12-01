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
            this.Database.EnsureCreated();

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
            //Album
            Album a1 = new Album { AlbumID = 1, Title = "Mike " };
            Album a2 = new Album { AlbumID = 2, Title = "Title 1" };
            Album a3 = new Album { AlbumID = 3, Title = "Title 2 " };
            Album a4 = new Album { AlbumID = 4, Title = "Title 3  " };
            Album a5 = new Album { AlbumID = 5, Title = "Title 4  " };
            Album a6 = new Album { AlbumID = 6, Title = "Title 5 " };
            Album a7 = new Album { AlbumID = 7, Title = "Title 6 " };
            Album a8 = new Album { AlbumID = 8, Title = "Title 7 " };
            Album a9 = new Album { AlbumID = 9, Title = "Title 8 " };
            Album a10 = new Album { AlbumID = 10, Title = "Title 10 " };
            //Track
            Track t1 = new Track { TrackId = 1, NamePlace = "ballads", Length = 10 };
            Track t2 = new Track { TrackId = 2, NamePlace = "novelty songs", Length = 15 };
            Track t3 = new Track { TrackId = 3, NamePlace = "anthems", Length = 20 };
            Track t4 = new Track { TrackId = 4, NamePlace = "rock", Length = 30 };
            Track t5 = new Track { TrackId = 5, NamePlace = "blues", Length = 40 };
            Track t6 = new Track { TrackId = 6, NamePlace = "life", Length = 50 };
            Track t7 = new Track { TrackId = 7, NamePlace = "soul songs", Length = 60 };
            Track t8 = new Track { TrackId = 8, NamePlace = "Pop ", Length = 70 };
            Track t9 = new Track { TrackId = 9, NamePlace = " Classical", Length = 80 };
            Track t10 = new Track { TrackId = 10, NamePlace = "Hip-Hop and Rap", Length = 75 };
            Track t11 = new Track { TrackId = 11, NamePlace = "EDM (Electronic Dance Music)", Length = 60 };
            Track t12 = new Track { TrackId = 12, NamePlace = "Metal", Length = 55 };
            //Artist
            Artist ar1 = new Artist { ArtistId = 1, Name = "David", Age = 4 };
            Artist ar2 = new Artist { ArtistId = 2, Name = "James ", Age = 33};
            Artist ar3 = new Artist { ArtistId = 3, Name = "Demi  ", Age = 23 };
            Artist ar4 = new Artist { ArtistId = 4, Name = "Diana  ", Age = 40 };
            Artist ar5 = new Artist { ArtistId = 5, Name = "Eminem ", Age = 25 };
            Artist ar6 = new Artist { ArtistId = 6, Name = "Eve ", Age = 40};
            Artist ar7 = new Artist { ArtistId = 7, Name = "Johnny  ", Age = 27 };
            Artist ar8 = new Artist { ArtistId = 8, Name = "Mate ", Age = 17 };
            Artist ar9 = new Artist { ArtistId = 9, Name = " Bill ", Age = 57 };
            Artist ar10 = new Artist { ArtistId = 10, Name = "Foxy ", Age = 60 };
            Artist ar11 = new Artist { ArtistId = 11, Name = "Rex ", Age = 33 };


            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(album => album.Track)
                    .WithMany(track => track.Albums)
                    .HasForeignKey(artist => artist.AlbumID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasOne(artist => artist.Album)
                    .WithMany(album => album.Artists)
                    .HasForeignKey(album => album.Albumid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            //HasData();
            modelBuilder.Entity<Track>().HasData(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11 , t12);
            modelBuilder.Entity<Album>().HasData(a1 , a2 ,a3 ,a4, a5 , a6 , a7 , a8 , a9 ,a9 ,a10);
            modelBuilder.Entity<Artist>().HasData(ar1, ar2 , ar3 ,ar4 , ar5,ar6,ar7,ar8,ar9,ar10,ar11);
        }

    }
}

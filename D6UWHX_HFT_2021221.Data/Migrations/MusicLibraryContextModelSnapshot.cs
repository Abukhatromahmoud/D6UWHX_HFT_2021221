using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Data.Migrations
{
    [DbContext(typeof(MusicLibraryContext))]
    partial class MusicLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("D6UWHX_HFT_2021221.Models.Album", b =>
            {
                b.Property<int>("AlbumID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Title")
                    .HasColumnType("nvarchar(max)");




                b.HasKey("TrackID");

                b.ToTable("Album");

                b.HasData(
                    new
                    {
                        AlbumID = 11,
                        Title = "Title 1",
                        TracktID = 1
                    },
                    new
                    {
                        AlbumID = 22,
                        Title = "Title 2",
                        TracktID = 1
                    },
                    new
                    {
                        AlbumID = 33,
                        Title = "Title 3",
                        TracktID = 1
                    });
            });

            modelBuilder.Entity("D6UWHX_HFT_2021221.Models.Artist", b =>
            {
                b.Property<int>("ArtistId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int?>("ArtistId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("Age")
                    .HasColumnType("int");

                b.HasKey("Albumid");

                b.ToTable("Track");

                b.HasData(
                    new
                    {
                        TrackId = 1,
                        NamePlace = "ballads",
                        Length = 10
                    },
                    new
                    {
                        TrackId = 2,
                        NamePlace = "novelty songs",
                        Length = 15
                    },
                    new
                    {
                        TrackId = 3,
                        NamePlace = "anthems",
                        Length = 20
                    });
            });

            modelBuilder.Entity("D6UWHX_HFT_2021221.Models.Track", b =>
            {
                b.Property<int>("TrackId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("NamePlace")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<double>("Length")
                    .HasColumnType("int");

                b.HasKey("AlbumId");

                b.ToTable("Track");

                b.HasData(
                    new
                    {
                        TrackId = 3,
                        NamePlace = "anthems",
                        Length = 20
                    },
                    new
                    {
                        TrackId = 4,
                        NamePlace = "rock",
                        Length = 30
                    },
                    new
                    {
                        TrackId = 5,
                        NamePlace = "blues",
                        Length = 40
                    });
            });
        }
    }
}

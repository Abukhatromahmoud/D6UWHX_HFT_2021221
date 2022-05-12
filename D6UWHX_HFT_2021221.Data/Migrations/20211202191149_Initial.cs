using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Data.Migrations
{
    public partial class _20211202191149_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("TracktID", x => x.AlbumID);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                   
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("Albumid", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<double>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AlbumId", x => x.TrackId);
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumID", "Titel", "TrackID" },
                values: new object[,]
                {
                    { 11, "Title 1", 1   },
                    {  22, "Title 2", 1  },
                    { 33, "Title 3", 1  }
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "Name", "Age" , "Albumid" },
                values: new object[,]
                {
                    { 1118, "David", 4, 11 },
                    { 222, "James", 3, 11  },
                    {333, "Demi" , 23 , 11 }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "TrackId", "NamePlace", "Length" },
                values: new object[,]
                {
                    { 1, "ballads", 10 },
                    { 2, "novelty songs",15 },
                    { 3, "anthems", 20}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Track");
        }
    
    
    }
}

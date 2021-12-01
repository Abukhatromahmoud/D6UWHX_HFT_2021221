using ConsoleTools;
using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace D6UWHX_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            //System.Threading.Thread.Sleep(8000);

            //RestService rest = new RestService("https://go.microsoft.com/fwlink/?LinkID=398940");

            //rest.Post<Track>(new Track()
            //{
            //    NamePlace = "ballads"
            //}, "ballads");

            //var tracks = rest.Get<Track>("novelty songs");
            //var tracks1 = rest.Get<Track>("rock");

            //double avgprice = rest.GetSingle<double>("stat/avgprice");

            //var avgpricebybrands = rest
            //    .Get<KeyValuePair<string, double>>("stat/avgpricebybrands");
            
            //
            MusicLibraryContext mlc = new MusicLibraryContext();
            AlbumRepository albumRepo = new AlbumRepository(mlc);
            TrackRepository trackRepo = new TrackRepository(mlc);
            ArtistRepository artistRepo = new ArtistRepository(mlc);
            TrackLogic trackLogic = new TrackLogic(trackRepo);
            AlbumLogic albumLogic = new AlbumLogic(albumRepo);
            ArtistLogic artistLogic = new ArtistLogic(artistRepo);

            var subMenuCreate = new ConsoleMenu()
                 .Add(">>ADD A NEW TRACK", () => AddNewTrack(trackLogic))
                 .Add(">> CREATE A NEW Album", () => AddNewAlbum(albumLogic))
                 .Add(">> ADD A NEW Artist TO the music", () => AddNewArtist(artistLogic))
                 .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Green;
                 });
            //
            var subMenuList = new ConsoleMenu()
                .Add(">> LIST ALL Tracks", () => ListAllTracks(trackLogic))
                .Add(">> LIST ALL ALBums", () => ListAllAlbum(albumLogic))
                .Add(">> LIST ALL ARTIST", () => ListAllArtist(artistLogic))

                .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Green;
                });
            var subMenuGetBy = new ConsoleMenu()
               .Add(">> GET ONE TRACK BY ID", () => GetOneTrack(trackLogic))
               .Add(">> GET ONE ALBUM BY ID", () => GetOneAlbum(albumLogic))
               .Add(">> GET ONE ARTIST BY ID", () => GetOneArtist(artistLogic))
               .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.DarkYellow;
               });

            var subMenuListRead = new ConsoleMenu()
               .Add(">> LIST ALL", () => subMenuList.Show())
               .Add(">> GET BY ID", () => subMenuGetBy.Show())
               .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.Green;
               });


            var subMenuMusic = new ConsoleMenu()
            .Add(">> C - CREATE", () => subMenuCreate.Show())
            //.Add(">> R - READ", () => subMenuCompanyRead.Show())
            //.Add(">> U - UPDATE", () => subMenuCompanyUpdate.Show())
            //.Add(">> D - DELETE", () => subMenuCompanyDelete.Show())
            //.Add(">> NON-CRUD - QUERIES", () => subMenuCompanyNonCrud.Show())
            .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.SelectedItemBackgroundColor = ConsoleColor.DarkYellow;
            });



            var menu = new ConsoleMenu()
              .Add(">> ENTER AS A VISITOR ", () => subMenuMusic.Show())
              
              .Add(">> EXIT", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.SelectedItemBackgroundColor = ConsoleColor.Cyan;
              });

            menu.Show();


        }
        private static void AddNewTrack(TrackLogic tracklogic)
        {
            try
            {
                Console.WriteLine("\n:: CREATING A NEW Track ::\n");
                Console.WriteLine("TYPE THE TrackId!");
                int TrackId = int.Parse(Console.ReadLine());
                Track TG = tracklogic.GetTrack(TrackId);
                Console.WriteLine("\n :: ADDED ::\n");
                Console.WriteLine(TG.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void AddNewAlbum(AlbumLogic albumlogic)
        {
            try
            {
                Console.WriteLine("\n:: CREATING A NEW Album ::\n");
                Console.WriteLine("TYPE THE AlbumId!");
                int albumID = int.Parse(Console.ReadLine());
                Album TG = albumlogic.GetAlbum(albumID);
                Console.WriteLine("\n :: ADDED ::\n");
                Console.WriteLine(TG.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void AddNewArtist(ArtistLogic artistlogic)
        {
            try
            {
                Console.WriteLine("\n:: CREATING A NEW Artist ::\n");
                Console.WriteLine("TYPE THE ArtistId!");
                int ArtistId = int.Parse(Console.ReadLine());
                Artist TG = artistlogic.GetArtist(ArtistId);
                Console.WriteLine("\n :: ADDED ::\n");
                Console.WriteLine(TG.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void ListAllTracks(TrackLogic trackLogic)
        {
            Console.WriteLine("\n:: ALL Tracks ::\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.ResetColor();
            trackLogic.GetTracks().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void ListAllArtist(ArtistLogic artistLogic)
        {
            Console.WriteLine("\n:: ALL Artist ::\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.ResetColor();
            artistLogic.GetArtists().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void ListAllAlbum(AlbumLogic albumLogic)
        {
            Console.WriteLine("\n:: ALL Album ::\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.ResetColor();
            albumLogic.GetAlbums().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void GetOneTrack(TrackLogic trackLogic)
        {
            Console.WriteLine("\n:: TYPE THE ID OF THE TRACK YOU WANT TO SEE ::\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.ResetColor();
                Console.WriteLine(trackLogic.GetTrack(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void GetOneAlbum(AlbumLogic albumLogic)
        {
            Console.WriteLine("\n:: TYPE THE ID OF THE ALBUM YOU WANT TO SEE ::\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.ResetColor();
                Console.WriteLine(albumLogic.GetAlbum(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void GetOneArtist(ArtistLogic artistLogic)
        {
            Console.WriteLine("\n:: TYPE THE ID OF THE ARTIST YOU WANT TO SEE ::\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.ResetColor();
                Console.WriteLine(artistLogic.GetArtist(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void GetShortestTrack(TrackLogic trackLogic)
        {
            Console.WriteLine("\n:: I WILL GIVE YOU THE SHORTEST TRACK ::\n");
            var item = trackLogic.GetShortestTrack();
            
        }



    }

}

    



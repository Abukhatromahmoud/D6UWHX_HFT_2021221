using ConsoleTools;
using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;


namespace D6UWHX_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:7000");

            rest.Post<Track>(new Track()
            {
                NamePlace = "ballads"
            }, "ballads");

            var tracks = rest.Get<Track>("novelty songs");
            var tracks1 = rest.Get<Track>("rock");

            double avgprice = rest.GetSingle<double>("stat/avgprice");

            var avgpricebybrands = rest
                .Get<KeyValuePair<string, double>>("stat/avgpricebybrands");
            
            //
            MusicLibraryContext mlc = new MusicLibraryContext();
            AlbumRepository albumRepo = new AlbumRepository(mlc);
            TrackRepository trackRepo = new TrackRepository(mlc);
            ArtistRepository artistRepo = new ArtistRepository(mlc);
            TrackLogic trackLogic = new TrackLogic(trackRepo);
            AlbumLogic albumLogic = new AlbumLogic(albumRepo);
            ArtistLogic artistLogic = new ArtistLogic(artistRepo);

            var subMenuCustomerCreate = new ConsoleMenu()
                 .Add(">>ADD A NEW TRACK", () => AddNewTrack(trackLogic))
                 .Add(">> CREATE A NEW Album", () => AddNewAlbum(albumLogic))
                 .Add(">> ADD A NEW Artist TO the music", () => AddNewArtist(artistLogic))
                 .Add(">> GO BACK TO MENU", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Green;
                 });
            var menu = new ConsoleMenu()
               .Add(">> ENTER AS A Track", () => subMenuCustomerCreate.Show())
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
    }
    
}

    



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

            RestService rest = new RestService("http://localhost:39135");

            rest.Post<Track>(new Track()
            {
                NamePlace = "ballads"
            }, "ballads");

            var tracks = rest.Get<Track>("novelty songs");
            var tracks1 = rest.Get<Track>("rock");

            double avgprice = rest.GetSingle<double>("stat/avgprice");

            var avgpricebybrands = rest
                .Get<KeyValuePair<string, double>>("stat/avgpricebybrands");
            ///
            ////
            MusicLibraryContext mlc = new MusicLibraryContext();
            AlbumRepository albumRepo = new AlbumRepository(mlc);
            TrackRepository trackRepo = new TrackRepository(mlc);
            ArtistRepository artistRepo = new ArtistRepository(mlc);
            TrackLogic trackLogic = new TrackLogic(trackRepo);
            AlbumLogic albumLogic = new AlbumLogic(albumRepo);
            ArtistLogic artistLogic = new ArtistLogic(artistRepo);


        
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
    }

    
}


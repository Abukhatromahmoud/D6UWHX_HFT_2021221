﻿using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
     public interface IArtistLogic
    {
        List<Artist> GetArtists();
        Artist GetArtist(int ArtistId);
        void CreatArtist(string name, int age , int albumId, int artistId);
        //AlbumID
        void UpdateArtist(Artist artist);
        void DeleteArtist(int ArtistId);
       
    }
}

using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    class ArtistLogic : IArtistLogic
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistLogic(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void CreatArtist(string name, int age,int albumId , int artistId)
        {
            Artist artist = new Artist
            {
                Name = name ,
                Age = age, 
                AlbumID = albumId,
                ArtistId = artistId
                
            };
            
            _artistRepository.Add(artist);

        }

        public void DeleteArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception("Not valid artist id");
            }

            _artistRepository.Delete(artist);
        }

        public  Artist GetArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception("Not valid artist id");
            }

            return artist;
        }

        public List<Artist> GetArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        // with this current update you cannot change the id, because it searches with it 
        public void UpdateArtist(Artist artist)
        {
            Artist currentArtist = _artistRepository
                .GetOne(artist.ArtistId);
            if (currentArtist == null)
            {

                throw new Exception("Not Existing ");
            }
            currentArtist.Age = artist.Age;
            currentArtist.Albums = artist.Albums;
            currentArtist.AlbumID = artist.AlbumID;
            currentArtist.Name = artist.Name;

            _artistRepository.Update(currentArtist);

        }
    }
}

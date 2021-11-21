using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    public  class AlbumLogic : IAlbumLogic
    {
        private readonly IAlbumRepository _albumRepository;
        
        public AlbumLogic(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;

        }

        public void CreateAlbum(int albumID, string title)
        {
            Album album = new Album
            { AlbumID = albumID , Title = title };
            _albumRepository.Add(album);

        }


        public void DeleteAlbum(int albumID)
        {
           Album album = _albumRepository.GetOne(albumID);
            
            if (album == null)
            {
                throw new Exception("Not valid album id");
            }

            _albumRepository.Delete(album);
        }

        public Album GetAlbum(int albumID)
        {
            Album album = _albumRepository.GetOne(albumID);
            if (album  == null)
            {
                throw new Exception("not valid albumId");
            }
            return album;
            
        }

        public List<Album> GetAlbums()
        {
            return _albumRepository.GetAll()
                    .ToList();
        }

        public void UpdateAlbum(Album album)
        {
            Album currentAlbum = _albumRepository.GetOne(album.AlbumID); 
            if (currentAlbum == null )
            {
                throw new Exception("Not Existing");
            }
            currentAlbum.Title = album.Title;

            _albumRepository.Update(currentAlbum);
        }
        public List<Album> GetAlbumRepositoryOrderedByTitle()
        {
            return _albumRepository.GetAll()
                .OrderBy(album => album.Title)
                .ToList();
        }

    }
}

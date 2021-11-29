using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        Album GetAlbumById(int Albumid);
        void CreateNewAlbum(Album album);
        void DeleteAlbumById(int Albumid);
        void ChangeAlbum(Album album);
        IList<Album> GetAllAlbums();
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
    }
    public  class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepo;

        public AlbumLogic(IAlbumRepository AlbumRepo)
        {
            this.albumRepo = AlbumRepo;
        }

        public void ChangeAlbum(Album album)
        {
            albumRepo.Update(album);
        }

        public void CreateNewAlbum(Album album)
        {
            if (album.Title == "" || album.Title == null)
                throw new NotImplementedException();
            else
                albumRepo.Create(album);
        }

        public void DeleteAlbumById(int Albumid)
        {
            albumRepo.Delete(Albumid);
        }

        public Album GetAlbumById(int Albumid)
        {
            if (Albumid < albumRepo.GetAll().Count())
                return albumRepo.Read(Albumid);
            else
                throw new IndexOutOfRangeException("[ERR] ID Is Unacceptable!");
        }

        public IList<Album> GetAllAlbums()
        {
            return albumRepo.GetAll().ToList();
        }

        public double AVGPrice()
        {
            return albumRepo.GetAll()
                .Average(t => t.BasePrice);
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from x in albumRepo.GetAll()
                   group x by x.Track.NamePlace into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice));
        }
    }
}

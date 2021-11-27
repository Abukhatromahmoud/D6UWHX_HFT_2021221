using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        MusicLibraryContext db;
        public AlbumRepository(MusicLibraryContext db)
        {
            this.db = db;
        }
        public void Create(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
        }
        public Album Read(int Albumid)
        {
            return
                db.Albums.FirstOrDefault(t => t.AlbumID == Albumid);
        }
        public IQueryable<Album> GetAll()
        {
            return db.Albums;
        }
        public void Delete(int Albumid)
        {
            var AlbumToDelete = Read(Albumid);
            db.Albums.Remove(AlbumToDelete);
            db.SaveChanges();
        }
        public void Update(Album album)
        {
            var AlbumToUpdate = Read(album.AlbumID);
            AlbumToUpdate.Title = album.Title;
            db.SaveChanges();
        }
    }
}

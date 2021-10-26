using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(MusicLibraryContext MusicLibraryContext) : base (MusicLibraryContext)
        {

        }

        public Album GetByTitle(string title)
        {
            return MusicLibraryContext
                 .Albums
                 .SingleOrDefault(album => album.Title == title);
        }

        public override Album GetOne(int id)
        {
            return MusicLibraryContext
                 .Albums
                 .SingleOrDefault(album => album.AlbumID == id);
        }
    }
}

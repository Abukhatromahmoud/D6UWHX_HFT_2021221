using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicLibraryContext musicLibraryContext) : base (musicLibraryContext    )
        {

        }

        public override Artist GetOne(int id)
        {
            return MusicLibraryContext
                .Artists
                .SingleOrDefault(artist => artist.ArtistId == id);
        
        }

    }
}

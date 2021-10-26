using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
    public class TrackRepository : Repository<Track> , ITrackRepository  
    {
        public TrackRepository(MusicLibraryContext  musicLibraryContext ) : base(musicLibraryContext)
        {
                
        }

        public override Track GetOne(int id)
        {
            return MusicLibraryContext
                .Tracks
                .SingleOrDefault(x => x.TrackId == id); 
        }

    }
}

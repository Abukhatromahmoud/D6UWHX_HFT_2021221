using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
   public  interface ITrackRepository
    {
        void Create(Track TrackEvent);
        void Delete(int Trackid);
        IQueryable<Track> GetAll();
        Track Read(int Trackid);
        void Update(Track TrackEvent);
    }
}

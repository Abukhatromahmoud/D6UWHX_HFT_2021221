using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    public interface ITrackLogic
    {
        List<Track> GetTracks();
        Track GetTrack(int TrackId);
        void CreatTrack(int TrackId, string NamePlace, int Length);
        void UpdateTrack(Track track);
        void DeleteTrack(int TrackId);

    }
}

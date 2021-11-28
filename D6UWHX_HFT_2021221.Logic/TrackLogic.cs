using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    public interface ITrackLogic
    {
        Track GetTrackById(int Trackid);
        void CreateNewTrack(Track track);
        void DeleteTrackById(int Trackid);
        void ChangeTrack(Track track);
        IList<Track> GetAllTracks();
    }
    public class TrackLogic : ITrackLogic
    {
        IAlbumRepository albumRepo;
        ITrackRepository trackRepo;
        private ITrackRepository @object;

        public TrackLogic(IAlbumRepository AlbumRepo, ITrackRepository TrackRepo)
        {
            this.albumRepo = AlbumRepo;
            this.trackRepo = TrackRepo;
        }

        public TrackLogic(ITrackRepository @object)
        {
            this.@object = @object;
        }

        public void ChangeTrack(Track track)
        {
            trackRepo.Update(track);
        }

        public void CreateNewTrack(Track track)
        {
            if (track.NamePlace == "" || track.NamePlace == null)
                throw new NotImplementedException();
            else
                trackRepo.Create(track);
        }

        public void DeleteTrackById(int Trackid)
        {
            trackRepo.Delete(Trackid);
        }

        public Track GetTrackById(int Trackid)
        {
            if (Trackid < trackRepo.GetAll().Count())
                return trackRepo.Read(Trackid);
            else
                throw new IndexOutOfRangeException("[ERR] ID Is Unacceptable!");
        }

        public IList<Track> GetAllTracks()
        {
            return trackRepo.GetAll().ToList();
        }

        public IEnumerable<Track> GetCommentNumberPerCategory()
        {
            var qx_sub = from x in trackRepo.GetAll()
                         group x by x.AlbumId into g
                         select new
                         {
                             album_ID = g.Key,
                             track_NO = g.Count()
                         };

            var qx = from x in albumRepo.GetAll()
                     join z in qx_sub on x.AlbumID equals z.album_ID
                     let joinedItem = new { x.AlbumID, x.Title, z.track_NO }
                     group joinedItem by joinedItem.Title into grp
                     select new Track
                     {
                         NamePlace = grp.Key,
                         Length = grp.Sum(x => x.track_NO)
                     };
            return qx;
        }
    }
}

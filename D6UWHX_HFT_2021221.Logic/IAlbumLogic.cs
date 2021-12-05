using D6UWHX_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        List<Album> GetAlbums();

        Album GetAlbum(int albumID);

        void CreateAlbum(int albumID, string title);

        void UpdateAlbum( Album album);

        void DeleteAlbum(int albumID);
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByAlbums();
    }
}

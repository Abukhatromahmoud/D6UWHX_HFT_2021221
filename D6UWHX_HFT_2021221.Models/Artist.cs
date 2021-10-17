using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Models
{
    
    public class Artist
    {
        public int  ArtistId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int AlbumID { get; set; }
        public virtual ICollection <Album> Albums { get; set; }
        public virtual ICollection <Track> Tracks { get; set; }






    }
}

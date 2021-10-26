using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string NamePlace { get; set; }
        public int Length { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        //fdsfdgdfgdsfghdf
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace D6UWHX_HFT_2021221.Models
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual  Artist Artist { get; set; }
        


    }
}

  



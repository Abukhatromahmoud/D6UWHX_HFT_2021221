
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

    [Table("Album")]
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AlbumID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int TracktID { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        [NotMapped]
        public virtual Track Track { get; set; }
        public double BasePrice { get; set; }
 
    }
    }




  



using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Models
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [NotMapped]
        public virtual Album Album { get; set; }
        
        [ForeignKey(nameof(Album))]
        public int? Albumid { get; set; }

        public override string ToString()
        {
            return $"\n{this.ArtistId,3} | {this.Name,-20} {this.Age,-28} {this.Album,5} {this.Album?.Title ?? "N/A",-40 } {this.Albumid,6} ";

        }
    }
}

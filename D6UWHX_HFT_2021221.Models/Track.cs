using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Models
{
    [Table("Track")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        [Required]
        [MaxLength(100)]
        public string NamePlace { get; set; }
        public int Length { get; set; }
        public int? AlbumId { get; set; }
        public virtual ICollection<Album> Albums { get; set; }


        public void CreateInstanceFromString(string input)
        {
            if (input.Contains("#"))
                throw new FormatException("not valid format");
            else
            {
                this.NamePlace = input.Split('%')[0];
                this.Length = int.Parse(input.Split('%')[1]);
            }
        }
        //fdsfdgdfgdsfghdf
    }
}

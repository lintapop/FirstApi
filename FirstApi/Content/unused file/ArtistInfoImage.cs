using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class ArtistInfoImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "藝術家圖片id")]
        public int id
        {
            get; set;
        }

        [Display(Name = "圖片連結")]
        public string imageUrl
        {
            get; set;
        }

        [Display(Name = "圖片簡介")]
        public string imageInfo
        {
            get; set;
        }

        [Display(Name = "外部關聯的實體")]
        public int artistInfoId
        {
            get; set;
        }

        [Display(Name = "外部關聯的虛擬id")]
        [ForeignKey("artistInfoId")]
        public virtual ArtistInfo ArtistInfos
        {
            get; set;
        }
    }
}
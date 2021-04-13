using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class ArtistInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "藝術家id")]
        public int id
        {
            get; set;
        }

        [Display(Name = "使用者id:外部關聯的實體")]
        public int userId
        {
            get; set;
        }

        [Display(Name = "使用者id:外部關聯父權限")]
        [ForeignKey("userId")] //這邊id對應user表單
        public virtual User Users
        {
            get; set;
        }

        [Display(Name = "藝術家介紹")]
        public string description
        {
            get; set;
        }

        [Display(Name = "藝術家照片")]
        public string images
        {
            get; set;
        }

        //沒有子關聯 所以註解掉
        //public virtual ICollection<ArtistInfoImage> ArtistInfoImages
        //{
        //    get; set;
        //}
    }
}
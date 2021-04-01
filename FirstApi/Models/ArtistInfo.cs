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
        [Display(Name = "藝術家編號")]
        public int id
        {
            get; set;
        }

        [Display(Name = "父權限-使用者id")]
        [ForeignKey("id")] //這邊id對應user表單
        public int userId
        {
            get; set;
        }
    }
}
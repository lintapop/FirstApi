using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Genre id")]
        public int Id
        {
            get; set;
        }

        [Display(Name = "分類名稱(油畫、雕刻)")]
        public string Name
        {
            get; set;
        }

        //一對多關聯給Product
        public virtual ICollection<Product> Products
        {
            get; set;
        }
    }
}
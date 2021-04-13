using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "使用者id")]
        public int Id
        {
            get; set;
        }

        [Display(Name = "product image url")]
        public string ImageUrl
        {
            get; set;
        }

        [Display(Name = "product image info")]
        public string ImageInfo
        {
            get; set;
        }

        [Display(Name = "外部關聯的實體-product id")]
        public int ProductId
        {
            get; set;
        }

        [Display(Name = "外部關聯的虛擬-Product id")]
        [ForeignKey("ProductId")]
        public virtual Product Products
        {
            get; set;
        }
    }
}
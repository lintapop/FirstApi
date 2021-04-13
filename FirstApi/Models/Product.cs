using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "product id")]
        public int Id
        {
            get; set;
        }

        [Display(Name = "外部關聯的實體-使用者id")]
        public int UserId
        {
            get; set;
        }

        [Display(Name = "外部關聯的虛擬-使用者id")]
        [ForeignKey("UserId")]
        public virtual User Users
        {
            get; set;
        }

        [Display(Name = "外部關聯的實體 genre id")]
        public int GenreId
        {
            get; set;
        }

        [Display(Name = "外部關聯的虛擬 genre id")]
        [ForeignKey("GenreId")]
        public virtual Genre Genres
        {
            get; set;
        }

        [Display(Name = "商品名稱")]
        public string Name
        {
            get; set;
        }

        [Display(Name = "商品詳細資料")]
        public string Description
        {
            get; set;
        }

        [Display(Name = "寬度")]
        public int Width
        {
            get; set;
        }

        [Display(Name = "高度")]
        public int Height
        {
            get; set;
        }

        [Display(Name = "競標價格")]
        public int BidPrice
        {
            get; set;
        }

        [Display(Name = "競標價格區間")]
        public int Interval
        {
            get; set;
        }

        [Display(Name = "競標起始時間")]
        public DateTime Start
        {
            get; set;
        }

        [Display(Name = "競標結束時間")]
        public DateTime End
        {
            get; set;
        }

        [Display(Name = "資料建立時間")]
        public DateTime CreatedAt
        {
            get; set;
        }

        [Display(Name = "預設關閉(尚未開始競標)")]
        public Boolean IsActive
        {
            get; set;
        }

        [Display(Name = "競標中")]
        public int Status
        {
            get; set;
        }

        [Display(Name = "圖片")]
        public string Images
        {
            get; set;
        }

        //外部關聯給Product Image
        public virtual ICollection<ProductImage> ProductImages
        {
            get; set;
        }
    }
}
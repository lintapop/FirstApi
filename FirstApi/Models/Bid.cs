using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class Bid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "競標品id")]
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

        [Display(Name = "外部關聯的實體-Product id")]
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

        [Display(Name = "資料建立時間")]
        public DateTime CreatedAt
        {
            get; set;
        }

        [Display(Name = "競標價格")]
        public int BidPrice
        {
            get; set;
        }
    }
}
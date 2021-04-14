using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "使用者id")]
        public int Id
        {
            get; set;
        }

        [Required]
        [Display(Name = "全名")]
        public string Fullname
        {
            get; set;
        }

        [Required]
        [Display(Name = "電子郵件")]
        [StringLength(30, ErrorMessage = "請輸入電子郵件")]
        [EmailAddress(ErrorMessage = "not legit email format")]
        public string Email
        {
            get; set;
        }

        [Required]
        [Display(Name = "登入密碼")]
        [StringLength(50, ErrorMessage = "超過", MinimumLength = 6)]
        public string Password
        {
            get; set;
        }

        [Display(Name = "密碼鹽")]
        [MaxLength(100)]
        public string PasswordSalt
        {
            get; set;
        }

        [Display(Name = "權限")]
        public string Authority
        {
            get; set;
        }

        [Display(Name = "使用者頭像")]
        public string Avatar
        {
            get; set;
        }

        [Display(Name = "會員創建時間")]
        public DateTime? CreatedAt
        {
            get; set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "超過", MinimumLength = 9)]
        [Display(Name = "手機號碼")]
        public string Phone
        {
            get; set;
        }

        [Display(Name = "是否為藝術家")]
        public Boolean IsArtist
        {
            get; set;
        }

        //   下面是關聯出去的表單名稱

        public virtual ICollection<ArtistInfo> ArtistInfos
        {
            get; set;
        }

        ////一對多關聯給Bid
        //public virtual ICollection<Bid> Bids
        //{
        //    get; set;
        //}

        //一對多關聯給Product
        public virtual ICollection<Product> Products
        {
            get; set;
        }
    }
}
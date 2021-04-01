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
        public int id
        {
            get; set;
        }

        [Required]
        [Display(Name = "全名")]
        public string fullname
        {
            get; set;
        }

        [Required]
        [Display(Name = "電子郵件")]
        [StringLength(30, ErrorMessage = "請輸入電子郵件")]
        [EmailAddress(ErrorMessage = "not legit email format")]
        public string email
        {
            get; set;
        }

        [Required]
        [Display(Name = "登入密碼")]
        [StringLength(50, ErrorMessage = "超過", MinimumLength = 6)]
        public string password
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
        public string avatar
        {
            get; set;
        }

        [Display(Name = "會員創建時間")]
        public DateTime? createdAt
        {
            get; set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "超過", MinimumLength = 9)]
        [Display(Name = "手機號碼")]
        public string phone
        {
            get; set;
        }

        [Display(Name = "是否為藝術家")]
        public Boolean isArtist
        {
            get; set;
        }

        //建立一對多關聯 (這邊是爸爸)
        public virtual ICollection<ArtistInfo> ArtistInfos
        {
            get; set;
        }
    }
}
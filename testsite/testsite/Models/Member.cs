using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testsite.Models
{
    public partial class Member
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        [Required(ErrorMessage = "{0}は必須です")]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayName("氏名カナ")]
        [Required(ErrorMessage = "{0}は必須です")]
        [RegularExpression(@"[｡-ﾟ+]+", ErrorMessage = "半角カタカナのみ入力できます。")]
        [StringLength(200)]
        public string NameKana { get; set; }

        [DisplayName("メールアドレス")]
        [EmailAddress(ErrorMessage = "正しいメールアドレスではありません。")]
        [Required(ErrorMessage = "{0}は必須です")]
        public string MailAddress { get; set; }

        [DisplayName("郵便番号")]
        [RegularExpression(@"\d{3}-\d{4}", ErrorMessage = "正しい郵便番号ではありません。")]
        public string PostNo { get; set; }

        [DisplayName("住所1")]
        [Required(ErrorMessage = "{0}は必須です")]
        [StringLength(255)]
        public string Address1 { get; set; }

        [DisplayName("住所2")]
        [StringLength(255)]
        public string Address2 { get; set; }

        [DisplayName("同意する")]
        [Required(ErrorMessage = "{0}は必須です")]
        public bool AgreePolicy { get; set; }

        [DisplayName("TwitterID")]
        [StringLength(15)]
        [RegularExpression(@"[0-9a-zA-Z_]+", ErrorMessage = "正しいTwitterIDではありません。")]
        public string Twitter { get; set; }

        [DisplayName("誕生日")]
        [Required(ErrorMessage = "{0}は必須です")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }

        [DisplayName("所属会社")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0}は必須です")]
        public string Office { get; set; }

        [DisplayName("仕事の種類")]
        [Required(ErrorMessage = "{0}は必須です")]
        public int JobTypeId { get; set; }

        [DisplayName("仕事の種類")]
        public JobType JobType { get; set; }

        [DisplayName("役職")]
        [StringLength(255)]
        public string Yakushoku { get; set; }

        [DisplayName("今までWACATEに来た回数")]
        [Range(0, 20)]
        [Required(ErrorMessage = "{0}は必須です")]
        public int RepeatCount { get; set; }

        [DisplayName("BlackWACATEへの連絡事項")]
        [StringLength(500)]
        public string Issue { get; set; }

        [DisplayName("最後に一言")]
        [StringLength(500)]
        public string UserNotes { get; set; }

        [DisplayName("申込日時")]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("有名ポイント")]
        [Range(0, 1000)]
        [Required(ErrorMessage = "{0}は必須です")]
        public int FamousPoint { get; set; }

        [DisplayName("スキルポイント")]
        [Range(0, 1000)]
        [Required(ErrorMessage = "{0}は必須です")]
        public int SkillPoint { get; set; }


        public bool? IsAccept { get; set; }

        [DisplayName("Vip対応")]
        public bool? IsVip { get; set; }

        [DisplayName("特記事項")]
        [StringLength(500)]
        public string WacateNotes { get; set; }

    }
}

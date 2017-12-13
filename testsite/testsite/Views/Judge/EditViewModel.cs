using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using testsite.Models;
using System.ComponentModel.DataAnnotations;

namespace testsite.Views.Judge
{
    public class EditViewModel
    {
        public int Id { get; set; }
        [DisplayName("氏名")]
        public string Name { get; set; }
        [DisplayName("氏名カナ")]
        public string NameKana { get; set; }
        [DisplayName("メールアドレス")]
        public string MailAddress { get; set; }
        [DisplayName("郵便番号")]
        public string PostNo { get; set; }
        [DisplayName("住所1")]
        public string Address1 { get; set; }
        [DisplayName("住所2")]
        public string Address2 { get; set; }
        [DisplayName("TwitterID")]
        public string Twitter { get; set; }
        [DisplayName("誕生日")]
        public DateTime? BirthDay { get; set; }
        [DisplayName("所属会社")]
        public string Office { get; set; }
        [DisplayName("仕事の種類")]
        public int JobTypeId { get; set; }
        [DisplayName("仕事の種類")]
        public JobType JobType { get; set; }
        [DisplayName("役職")]
        public string Yakushoku { get; set; }
        [DisplayName("WACATEに来た回数")]
        public int RepeatCount { get; set; }
        [DisplayName("B連絡事項")]
        public string Issue { get; set; }
        [DisplayName("最後に一言")]
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
        public bool IsVip { get; set; }

        [DisplayName("特記事項")]
        [StringLength(500)]
        public string WacateNotes { get; set; }

        public string ConfilmDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using testsite.Models;

namespace testsite.Views.Accept
{
    public class ConfilmViewModel
    {
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
        [DisplayName("連絡事項")]
        public string Issue { get; set; }
        [DisplayName("最後に一言")]
        public string UserNotes { get; set; }

        public string ConfilmDate { get; set; }
    }
}

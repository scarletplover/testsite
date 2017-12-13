using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testsite.Views.Accept
{
    public class Accept1ViewModel
    {
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
        [Required(ErrorMessage = "{0}は必須です")]
        public string PostNo { get; set; }

        [DisplayName("住所1")]
        [Required(ErrorMessage = "{0}は必須です")]
        [StringLength(255)]
        public string Address1 { get; set; }

        [DisplayName("住所2")]
        [StringLength(255)]
        public string Address2 { get; set; }

        [DisplayName("誕生日")]
        [Required(ErrorMessage = "{0}は必須です")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
    }
}

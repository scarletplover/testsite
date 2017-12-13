using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace testsite.Views.Judge
{
    public class IndexViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("氏名")]
        public string Name { get; set; }
        [DisplayName("氏名カナ")]
        public string NameKana { get; set; }
        [DisplayName("仕事の種類")]
        public string JobType { get; set; }
        [DisplayName("所属会社")]
        public string Office { get; set; }
        [DisplayName("参加可否")]
        public bool? IsAccept { get; set; }

    }
}

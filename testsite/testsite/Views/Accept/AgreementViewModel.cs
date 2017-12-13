using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testsite.Views.Accept
{
    public partial class AgreementViewModel
    {
        [DisplayName("同意する")]
        [Required(ErrorMessage = "{0}は必須です")]
        public bool AgreePolicy { get; set; }
    }
}

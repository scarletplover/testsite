using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testsite.Models
{
    public partial class JobType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public static void Initialize(AcceptContext context)
        {
            var t = context.Set<JobType>();
            if(t.Any()==false)
            {
                t.AddRange(
                    new JobType() { Type = "テスト実施者" },
                    new JobType() { Type= "テストエンジニア" },
                    new JobType() { Type = "テストマネージャ" },
                    new JobType() { Type = "テストマネージャ" },
                    new JobType() { Type = "ソフトウェア開発者" },
                    new JobType() { Type = "マネージャ" },
                    new JobType() { Type = "ITアーキテクト" },
                    new JobType() { Type = "コンサルティング" },
                    new JobType() { Type = "経営者・管理職" },
                    new JobType() { Type = "研究・教育" },
                    new JobType() { Type = "その他" }
                );
                context.SaveChanges();
            }
        }
    }
}

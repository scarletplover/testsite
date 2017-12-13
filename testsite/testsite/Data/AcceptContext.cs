using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testsite.Models
{
    public class AcceptContext : DbContext
    {
        public AcceptContext (DbContextOptions<AcceptContext> options)
            : base(options)
        {
        }

        public DbSet<testsite.Models.Member> Members { get; set; }
        public DbSet<testsite.Models.JobType> JobTypes { get; set; }
    }
}

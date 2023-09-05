using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Models;

namespace PDMasterDetail.Data
{
    public class PDMasterDetailContext : DbContext
    {
        public PDMasterDetailContext (DbContextOptions<PDMasterDetailContext> options)
            : base(options)
        {
        }

        public DbSet<PDMasterDetail.Models.Resources> Resources { get; set; } = default!;
    }
}

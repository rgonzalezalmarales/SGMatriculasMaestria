using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCompras.Models
{
    public class ComprasDbContext: DbContext
    {
        public DbSet<Presupuesto> Presupuesto { get; set; }

        public ComprasDbContext(DbContextOptions<ComprasDbContext> options): base(options)
        {
                
        }
    }
}

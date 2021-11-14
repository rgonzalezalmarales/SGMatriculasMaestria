using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPagination.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> Person { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }
    }
}

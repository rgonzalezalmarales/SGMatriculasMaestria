using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGMatriculasMaestria.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<CategDocente> CategDocentes { get; set; }
        public DbSet<CentroTrabajo> CentroTrabajos { get; set; }
        public DbSet<Ces> Ces { get; set; }
        public DbSet<EspecGraduado> EspecGraduados { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Maestria> Maestrias { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<SecretarioPostg> SecretarioPostgrados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Aspirante>()
                .HasKey(x => new { x.CI });           
        }


    }
}

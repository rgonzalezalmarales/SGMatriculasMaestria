using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGMatriculasMaestria.Data
{
    public class ApplicationDbContext : IdentityDbContext<AplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public virtual DbSet<Aspirante> Aspirantes { get; set; }
        public virtual DbSet<CategDocente> CategDocentes { get; set; }
        public virtual DbSet<CentroTrabajo> CentroTrabajos { get; set; }
        public virtual DbSet<Ces> Ces { get; set; }
        public virtual DbSet<EspecGraduado> EspecGraduados { get; set; }
        public virtual DbSet<Facultad> Facultades { get; set; }
        public virtual DbSet<Maestria> Maestrias { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<SecretarioPostg> SecretarioPostgrados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Aspirante>()
                .HasKey(x => new { x.CI });           
        }


    }
}

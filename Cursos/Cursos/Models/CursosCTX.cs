using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class CursosCTX : DbContext
    {
        public CursosCTX()
        {
        }

        public CursosCTX(DbContextOptions<CursosCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<InscripcionCurso> InscripcionCurso { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Cursos;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6CA998734");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripsion).IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C24402EC4DB");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.NombreApellido)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([Nombre],' ',[Apellido]))");
            });

            modelBuilder.Entity<InscripcionCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo, e.IdCurso })
                    .HasName("PK__Inscripc__994C4A9C26CE3018");

                //Relación con Curso
                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.InscripcionCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inscripci__IdCur__2E1BDC42");

                //Relacón con Matricula
                //Las configuraciones se hacen en la clase secundaria
                entity.HasOne(d => d.Matricula) //Esto hace ref a un objeto InscripcionCurso (Clase secundaria)
                    .WithMany(p => p.InscripcionCurso) //Esto hace ref a un objeto Matricula (Clase primaria)
                    .HasForeignKey(d => new { d.IdEstudiante, d.IdPeriodo}) //Esto hace ref a un objeto InscripcionCurso (Clase secundaria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InscripcionCurso__2D27B809"); //Clase secundaria
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo })
                    .HasName("PK__Matricul__4E4415BB76E531B5");

                //Relación con estudiante
                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdEst__2B3F6F97");

                //Relación con Período
                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdPer__2C3393D0");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PK__Periodo__B44699FEADA377A0");

                entity.Property(e => e.IdPeriodo).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

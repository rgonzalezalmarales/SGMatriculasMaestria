﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGMatriculasMaestria.Data;

namespace SGMatriculasMaestria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Aspirante", b =>
                {
                    b.Property<string>("CI")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("CesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Creatat")
                        .HasColumnType("datetime2");

                    b.Property<string>("DireccionParticular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EspecGraduadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaGraduacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Folio")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modifiat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tomo")
                        .HasColumnType("int");

                    b.HasKey("CI");

                    b.HasIndex("CesId");

                    b.HasIndex("EspecGraduadoId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PaisId");

                    b.ToTable("Aspirantes");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.CategDocente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategDocentes");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.CentroTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.ToTable("CentroTrabajos");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Ces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Ces");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.EspecGraduado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EspecGraduados");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Facultad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facultades");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Maestria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultadId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultadId");

                    b.ToTable("Maestrias");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnoExperienciaLaboral")
                        .HasColumnType("int");

                    b.Property<string>("AspiranteCI")
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("CategDocenteId")
                        .HasColumnType("int");

                    b.Property<int>("CentroTrabajoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCulminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMatricula")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaestriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modifiat")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotivoSolicitud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecretarioPostgId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AspiranteCI");

                    b.HasIndex("CategDocenteId");

                    b.HasIndex("CentroTrabajoId");

                    b.HasIndex("MaestriaId");

                    b.HasIndex("SecretarioPostgId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinciaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                       ;

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provincia");

                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.SecretarioPostg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecretarioPostgrados");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Aspirante", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Ces", "Ces")
                        .WithMany("Aspirantes")
                        .HasForeignKey("CesId");

                    b.HasOne("SGMatriculasMaestria.Models.EspecGraduado", "EspecGraduado")
                        .WithMany("Aspirantes")
                        .HasForeignKey("EspecGraduadoId");

                    b.HasOne("SGMatriculasMaestria.Models.Municipio", "Municipio")
                        .WithMany("Aspirantes")
                        .HasForeignKey("MunicipioId");

                    b.HasOne("SGMatriculasMaestria.Models.Pais", "Pais")
                        .WithMany("Aspirantes")
                        .HasForeignKey("PaisId");

                    b.Navigation("Ces");

                    b.Navigation("EspecGraduado");

                    b.Navigation("Municipio");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.CentroTrabajo", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Municipio", "Municipio")
                        .WithMany("CentroTrabajos")
                        .HasForeignKey("MunicipioId");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Ces", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Municipio", "Municipio")
                        .WithMany("Ces")
                        .HasForeignKey("MunicipioId");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Maestria", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Facultad", "Facultad")
                        .WithMany("Maestrias")
                        .HasForeignKey("FacultadId");

                    b.Navigation("Facultad");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Matricula", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Aspirante", "Aspirante")
                        .WithMany()
                        .HasForeignKey("AspiranteCI");

                    b.HasOne("SGMatriculasMaestria.Models.CategDocente", "CategDocente")
                        .WithMany("Matriculas")
                        .HasForeignKey("CategDocenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGMatriculasMaestria.Models.CentroTrabajo", "CentroTrabajo")
                        .WithMany("Matriculas")
                        .HasForeignKey("CentroTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGMatriculasMaestria.Models.Maestria", "Maestria")
                        .WithMany("Matriculas")
                        .HasForeignKey("MaestriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGMatriculasMaestria.Models.SecretarioPostg", "SecretarioPostg")
                        .WithMany("Matriculas")
                        .HasForeignKey("SecretarioPostgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aspirante");

                    b.Navigation("CategDocente");

                    b.Navigation("CentroTrabajo");

                    b.Navigation("Maestria");

                    b.Navigation("SecretarioPostg");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Municipio", b =>
                {
                    b.HasOne("SGMatriculasMaestria.Models.Provincia", "Provincia")
                        .WithMany("Municipios")
                        .HasForeignKey("ProvinciaId");

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.CategDocente", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.CentroTrabajo", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Ces", b =>
                {
                    b.Navigation("Aspirantes");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.EspecGraduado", b =>
                {
                    b.Navigation("Aspirantes");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Facultad", b =>
                {
                    b.Navigation("Maestrias");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Maestria", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Municipio", b =>
                {
                    b.Navigation("Aspirantes");

                    b.Navigation("CentroTrabajos");

                    b.Navigation("Ces");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Pais", b =>
                {
                    b.Navigation("Aspirantes");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.Provincia", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("SGMatriculasMaestria.Models.SecretarioPostg", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OngBackEnd.DataContext;

namespace OngBackEnd.Migrations
{
    [DbContext(typeof(ONGDataContext))]
    partial class ONGDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OngBackEnd.Models.AlumnoModel", b =>
                {
                    b.Property<int>("IdAlumno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaN");

                    b.Property<string>("Grado");

                    b.Property<string>("Nombre");

                    b.Property<int>("Seccion");

                    b.Property<string>("pass");

                    b.HasKey("IdAlumno");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("OngBackEnd.Models.AsignaturaModel", b =>
                {
                    b.Property<int>("IdAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Asignatura");

                    b.Property<int>("IdGrado");

                    b.HasKey("IdAsignatura");

                    b.HasIndex("IdGrado");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("OngBackEnd.Models.GradoMaestroModel", b =>
                {
                    b.Property<int>("IdGrado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grado");

                    b.Property<string>("Jornada");

                    b.HasKey("IdGrado");

                    b.ToTable("GradoMaestros");
                });

            modelBuilder.Entity("OngBackEnd.Models.GradoModel", b =>
                {
                    b.Property<int>("IdGrado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grado");

                    b.Property<string>("Jornada");

                    b.HasKey("IdGrado");

                    b.ToTable("Grados");
                });

            modelBuilder.Entity("OngBackEnd.Models.HistorialAcModel", b =>
                {
                    b.Property<int>("IdHistoriaAc")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAlumno");

                    b.Property<int>("IdSemestre");

                    b.Property<int>("Notas");

                    b.Property<string>("Observaciones");

                    b.HasKey("IdHistoriaAc");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdSemestre");

                    b.ToTable("HistorialAcs");
                });

            modelBuilder.Entity("OngBackEnd.Models.MaestroAsignaturaModel", b =>
                {
                    b.Property<int>("IdMaestroAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAsignatura");

                    b.Property<int>("IdMaestro");

                    b.HasKey("IdMaestroAsignatura");

                    b.HasIndex("IdAsignatura");

                    b.HasIndex("IdMaestro");

                    b.ToTable("MaestroAsignaturas");
                });

            modelBuilder.Entity("OngBackEnd.Models.MaestroModel", b =>
                {
                    b.Property<int>("IdMaestro")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Grado");

                    b.Property<string>("Nombre");

                    b.Property<string>("Seccion");

                    b.Property<string>("pass");

                    b.HasKey("IdMaestro");

                    b.ToTable("Maestros");
                });

            modelBuilder.Entity("OngBackEnd.Models.NotaModel", b =>
                {
                    b.Property<int>("IdNota")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAlumno");

                    b.Property<int>("IdAsignatura");

                    b.Property<int>("IdSemestre");

                    b.Property<int>("NotaAcum");

                    b.Property<int>("NotaExa");

                    b.Property<int>("P1");

                    b.Property<int>("P2");

                    b.Property<int>("P3");

                    b.Property<int>("P4");

                    b.Property<int>("Total");

                    b.HasKey("IdNota");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdAsignatura");

                    b.HasIndex("IdSemestre");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("OngBackEnd.Models.RolModel", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rol");

                    b.HasKey("IdRol");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("OngBackEnd.Models.SemestreModel", b =>
                {
                    b.Property<int>("IdSemestre")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Semestre");

                    b.HasKey("IdSemestre");

                    b.ToTable("Semestres");
                });

            modelBuilder.Entity("OngBackEnd.Models.AsignaturaModel", b =>
                {
                    b.HasOne("OngBackEnd.Models.GradoModel", "Grado")
                        .WithMany()
                        .HasForeignKey("IdGrado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OngBackEnd.Models.HistorialAcModel", b =>
                {
                    b.HasOne("OngBackEnd.Models.AlumnoModel", "Alumno")
                        .WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OngBackEnd.Models.SemestreModel", "Semestre")
                        .WithMany()
                        .HasForeignKey("IdSemestre")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OngBackEnd.Models.MaestroAsignaturaModel", b =>
                {
                    b.HasOne("OngBackEnd.Models.AsignaturaModel", "Asignatura")
                        .WithMany()
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OngBackEnd.Models.MaestroModel", "Maestro")
                        .WithMany()
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OngBackEnd.Models.NotaModel", b =>
                {
                    b.HasOne("OngBackEnd.Models.AlumnoModel", "Alumno")
                        .WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OngBackEnd.Models.AsignaturaModel", "Asignatura")
                        .WithMany()
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OngBackEnd.Models.SemestreModel", "Semestre")
                        .WithMany()
                        .HasForeignKey("IdSemestre")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OngBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.DataContext
{
    public class ONGDataContext: DbContext
    {
        public DbSet<Alumno>Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<GradoMaestro> GradoMaestros { get; set; }
        public DbSet<HistorialAc> HistorialAcs { get; set; }
        public DbSet<MaestroAsignatura> MaestroAsignaturas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Maestro> Maestros { get; set; }

        public DbSet<Rol> Rols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=gildantest;User=sa;password=falcon1*;DataBase=ONGDB;Trusted_Connection=false;");


        }   


    }
}

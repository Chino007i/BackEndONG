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
        public DbSet<AlumnoModel>Alumnos { get; set; }
        public DbSet<AsignaturaModel> Asignaturas { get; set; }
        public DbSet<GradoModel> Grados { get; set; }
        public DbSet<GradoMaestroModel> GradoMaestros { get; set; }
        public DbSet<HistorialAcModel> HistorialAcs { get; set; }
        public DbSet<MaestroModel> Maestros { get; set; }
        public DbSet<MaestroAsignaturaModel> MaestroAsignaturas { get; set; }
        public DbSet<NotaModel> Notas { get; set; }
        public DbSet<SemestreModel> Semestres { get; set; }

        public DbSet<RolModel> Rols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlServer(@"Server=gildantest;User=sa;password=falcon1*;DataBase=ONGDB;Trusted_Connection=false;");

            optionBuilder.UseSqlServer(@"Server=Morales-CIT;Database=ONGDB;Trusted_Connection=True;");
        }   


    }
}

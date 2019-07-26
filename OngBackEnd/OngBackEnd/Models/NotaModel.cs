using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class NotaModel
    {
        [Key]
        public int IdNota { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int NotaAcum { get; set; }
        public int NotaExa { get; set; }
        public int Total { get; set; }

        [ForeignKey("Semestre")]
        public int IdSemestre { get; set; }
        public SemestreModel Semestre { get; set; }

        [ForeignKey("Alumno")]
        public int IdAlumno { get; set; }
        public AlumnoModel Alumno { get; set; }

        [ForeignKey("Asignatura")]
        public int IdAsignatura { get; set; }
        public AsignaturaModel Asignatura { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class HistorialAcModel
    {
        [Key]
        public int IdHistoriaAc { get; set; }
        public int Notas { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Alumno")]
        public int IdAlumno { get; set; }
        public AlumnoModel Alumno { get; set; }

        [ForeignKey("Semestre")]
        public int IdSemestre { get; set; }
        public SemestreModel Semestre { get; set; }
    }
}

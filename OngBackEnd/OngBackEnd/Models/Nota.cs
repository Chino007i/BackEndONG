using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Nota
    {
        [Key]
        public int IdSemestre { get; set; }
        public int IdAlumno { get; set; }
        public int IdAsignatura { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int NotaAcum { get; set; }
        public int NotaExa { get; set; }
        public int Total { get; set; }

    }
}

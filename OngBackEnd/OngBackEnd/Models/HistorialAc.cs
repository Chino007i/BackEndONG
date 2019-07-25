using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class HistorialAc
    {
        [Key]
        public int IdAlumno { get; set; }
        public int IdSemestre { get; set; }
        public int Notas { get; set; }
        public String Observaciones { get; set; }
    }
}

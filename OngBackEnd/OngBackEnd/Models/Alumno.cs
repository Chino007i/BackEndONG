using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Alumno
    {

        [Key]
        public int IdAlumno { get; set; }
        public String Nombre { get; set; }
        public string Apellido { get; set; }
        public string pass { get; set; }
        public DateTime FechaN { get; set; }
        public string Grado { get; set; }
        public int Seccion { get; set; }
        public string Direccion { get; set; }

    }
}

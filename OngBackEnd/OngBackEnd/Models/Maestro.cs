using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Maestro
    {
        [Key]
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string pass { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
    }
}

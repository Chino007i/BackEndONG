using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class GradoMaestroModel
    {
        [Key]
        public int IdGrado { get; set; }
        public string Grado { get; set; }
        public string Jornada { get; set; }
    }
}

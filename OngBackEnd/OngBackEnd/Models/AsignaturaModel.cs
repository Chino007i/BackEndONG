using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class AsignaturaModel
    {
        [Key]
        public int IdAsignatura { get; set; }
        public string Asignatura{ get; set; }

        [ForeignKey ("Grado")]
        public int IdGrado { get; set; }
        public GradoModel Grado { get; set; }

        [ForeignKey ("GradoMaestro")]
        public int IdGradoMaestro { get; set; }
        public GradoMaestroModel GradoMaestro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class MaestroAsignaturaModel
    {
        [Key]
        public int IdMaestroAsignatura { get; set; }
        
        [ForeignKey("Maestro")]
        public int IdMaestro { get; set; }
        public MaestroModel Maestro { get; set; }

        [ForeignKey("Asignatura")]
        public int IdAsignatura { get; set; }
        public AsignaturaModel Asignatura { get; set; }

    }
}

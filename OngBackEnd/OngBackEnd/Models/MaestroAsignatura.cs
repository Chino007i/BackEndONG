using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class MaestroAsignatura
    {
        [Key]
        public int IdMaestro { get; set; }
        public int IdAsignatura { get; set; }
      
    }
}

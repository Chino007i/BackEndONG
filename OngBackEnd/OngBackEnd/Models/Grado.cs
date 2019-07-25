using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Grado
    {
        [Key]
        public int IdGrado { get; set; }
        public string Grados { get; set; }
        public string Jornada { get; set; }
    }
}

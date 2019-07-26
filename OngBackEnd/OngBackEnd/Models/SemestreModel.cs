using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class SemestreModel
    {
        [Key]
        public int IdSemestre { get; set; }
        public int Semestre { get; set; }
    }
}

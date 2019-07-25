using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Asignatura
    {
        [Key]
        public int IdAsignatura { get; set; }
        public String Asignatur{ get; set; }
        public int IdGrado { get; set; }
    }
}

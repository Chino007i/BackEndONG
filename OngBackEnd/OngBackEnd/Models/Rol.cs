using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string TRol { get; set; }
    }
}

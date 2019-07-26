using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngBackEnd.Models
{
    public class RolModel
    {
        [Key]
        public int IdRol { get; set; }
        public string Rol { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBCompras.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        
        [Required]
        public string proveedor { get; set; }
        public string fecha { get; set; }
        public string pbase { get; set; }
        public string iva { get; set; }
        public string total { get; set; }
    }
}

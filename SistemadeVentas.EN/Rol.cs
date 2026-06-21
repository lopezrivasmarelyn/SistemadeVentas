using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
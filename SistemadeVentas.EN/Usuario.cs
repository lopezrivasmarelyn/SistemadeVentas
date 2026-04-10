using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; } // FK
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Telefono { get; set; } 
        public string Clave { get; set; }
        public string Estado { get; set; } 
        public DateTime FechaRegistro { get; set; } 

        [NotMapped]
        public int Top_Aux { get; set; }

        //Navegacion
        public virtual Rol Rol { get; set; }
    }
}

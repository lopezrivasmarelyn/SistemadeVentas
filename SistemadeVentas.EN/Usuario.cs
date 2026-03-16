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
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Rol Rol { get; set; } = new Rol();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; } // FK
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal Total { get; set; } = decimal.Zero;
        public string TipoPago { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }
}

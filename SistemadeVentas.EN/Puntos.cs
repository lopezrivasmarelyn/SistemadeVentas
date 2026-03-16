using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Puntos
    {
        public int IdPuntos { get; set; }
        public int IdUsuario { get; set; } // FK
        public int PuntosAcumulados { get; set; } = 0;
        public string CodigoDescuento { get; set; } = string.Empty;
        public decimal PorcentajeDescuento { get; set; } = decimal.Zero;
        public DateTime FechaGenerarCodigo { get; set; } = DateTime.Now;
        public DateTime FechaExpiracionCodigo { get; set; }
        public string EstadoCodigo { get; set; } = string.Empty;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }
}

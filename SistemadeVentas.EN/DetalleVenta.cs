using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; } // FK
        public int IdProducto { get; set; } //FK
        public int Cantidad { get; set; } = 0;
        public decimal PrecioUnitario { get; set; } = decimal.Zero;
        public decimal SubTotal { get; set; } = decimal.Zero;

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Venta Venta { get; set; } = new Venta();

        public virtual Producto Producto { get; set; } = new Producto();

    }
}

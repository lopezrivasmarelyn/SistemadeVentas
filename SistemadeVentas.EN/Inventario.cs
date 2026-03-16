using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; } //FK
        public int StockAnual { get; set; } = 0;
        public int StockMinimo { get; set; } = 0;
        public DateTime UltimaActualizacion { get; set; } = DateTime.Now;

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Producto Producto { get; set; } = new Producto();

    }
}

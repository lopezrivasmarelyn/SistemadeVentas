using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; } // FK
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; } = decimal.Zero;
        public string Estado { get; set; } = string.Empty;

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Categoria Categoria { get; set; } = new Categoria();

    }
}

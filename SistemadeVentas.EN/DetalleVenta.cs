using System.ComponentModel.DataAnnotations.Schema;
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
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } 
        public decimal SubTotal { get; set; }
        public string ImagenUrl { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        // --- PROPIEDADES DE NAVEGACIÓN ---
        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }

    }
}

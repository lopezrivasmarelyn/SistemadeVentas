using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int StockAnual { get; set; }
        public int StockMinimo { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
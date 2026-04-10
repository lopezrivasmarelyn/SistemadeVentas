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
        public int IdInventario { get; set; }
        public int IdProducto { get; set; } //FK
        public int StockAnual { get; set; } 
        public int StockMinimo { get; set; } 
        public DateTime UltimaActualizacion { get; set; } 

        [NotMapped]
        public int Top_Aux { get; set; }

        //Navegacion

        public virtual Producto Producto { get; set; }

    }
}

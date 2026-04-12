using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string TipoPago { get; set; }
        public string Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
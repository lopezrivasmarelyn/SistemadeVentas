using System.ComponentModel.DataAnnotations.Schema;
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
        public string CodigoDescuento { get; set; }
        public int PorcentajeDescuento { get; set; }
        public DateTime FechaGenerarCodigo { get; set; } 
        public DateTime FechaExpiracionCodigo { get; set; }
        public string EstadoCodigo { get; set; } 
        public DateTime FechaActualizacion { get; set; } 

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}

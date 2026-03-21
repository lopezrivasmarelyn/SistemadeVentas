using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeVentas.EN
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public string Estado { get; set; } 

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}

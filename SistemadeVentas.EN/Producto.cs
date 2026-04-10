using System.ComponentModel.DataAnnotations.Schema;
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
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public int Precio { get; set; } 
        public string Estado { get; set; } 

        [NotMapped]
        public int Top_Aux { get; set; }

        //Navegacion

        public virtual Categoria Categoria { get; set; }

    }
}

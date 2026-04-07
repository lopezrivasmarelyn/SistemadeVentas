using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.IUMVC.Models
{
    public class Inventario
    {

        [Key]
        public int Id { get; set; }


        [ForeignKey("Producto")]
        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El stock anual es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        [Display(Name = "Stock Anual")]
        public int StockAnual { get; set; }

        [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
        [Display(Name = "Stock Mínimo")]
        public int StockMinimo { get; set; }

        [Required(ErrorMessage = "La última actualización es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Última Actualización")]
        public DateTime UltimaActualizacion { get; set; }

        // ── PROPIEDAD DE NAVEGACIÓN ──
        public virtual Producto Producto { get; set; }
    }
}
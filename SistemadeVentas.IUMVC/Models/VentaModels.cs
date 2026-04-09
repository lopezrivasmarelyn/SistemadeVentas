using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.IUMVC.Models
{
    public class Venta
    {
      
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "La fecha de venta es obligatoria.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Venta")]
        public DateTime FechaVenta { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser un número positivo.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El tipo de pago es obligatorio.")]
        [Display(Name = "Tipo de Pago")]
        public string TipoPago { get; set; }

        [Required(ErrorMessage = "El estatus es obligatorio.")]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }

        
        // Una Venta pertenece a un Usuario
        public virtual Usuario Usuario { get; set; }

        // Una Venta puede tener muchos Detalle_Venta
        public virtual ICollection<Detalle_Venta> DetallesVenta { get; set; }
    }
}
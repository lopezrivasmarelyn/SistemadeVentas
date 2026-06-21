using SistemadeVentas.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.IUMVC.Models
{
    public class DetalleVentaModels
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Venta")]
        [Required(ErrorMessage = "Venta obligatoria.")]
        [Display(Name = "Venta")]
        public int IdVenta { get; set; }


        [ForeignKey("Producto")]
        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Display(Name = "PrecioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }

        public virtual Venta Venta { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}

using SistemadeVentas.EN;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.IUMVC.Models
{
    public class PuntosModels
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Los puntos acumulados son obligatorios.")]
        [Range(0, int.MaxValue, ErrorMessage = "Los puntos no pueden ser negativos.")]
        [Display(Name = "Puntos Acumulados")]
        public int PuntosAcumulados { get; set; }

        [Required(ErrorMessage = "El código de descuento es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Código Descuento")]
        public string CodigoDescuento { get; set; }

        [Required(ErrorMessage = "El porcentaje de descuento es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Porcentaje Descuento")]
        public decimal PorcentajeDescuento { get; set; }

        [Required(ErrorMessage = "La fecha de generación es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Generación Código")]
        public DateTime FechaGeneracionCodigo { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Expiración Código")]
        public DateTime FechaExpiracionCodigo { get; set; }

        [Required(ErrorMessage = "El estado del código es obligatorio.")]
        [StringLength(20)]
        [Display(Name = "Estado del Código")]
        public string EstadoCodigo { get; set; }

        [Required(ErrorMessage = "La fecha de actualización es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Actualización")]
        public DateTime FechaActualizacion { get; set; }

        
        public virtual Usuario Usuario { get; set; }
    }
}
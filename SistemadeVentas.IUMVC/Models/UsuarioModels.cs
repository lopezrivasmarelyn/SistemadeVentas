using SistemadeVentas.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.IUMVC.Models
{
    public class UsuarioModels
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "El rol es obligatorio.")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Numero de telefono es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria.")]
        [StringLength(50)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "El estatus es obligatorio.")]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        [Display(Name = "FechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual ICollection<Rol> Roles { get; set; }
    }
}

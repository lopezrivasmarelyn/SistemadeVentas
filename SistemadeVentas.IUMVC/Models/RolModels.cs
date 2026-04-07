using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemadeVentas.IUMVC.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

       
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
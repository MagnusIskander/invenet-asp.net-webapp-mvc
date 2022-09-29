using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INVENNET.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(3, ErrorMessage = "Este registro es demaciado corto")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(10, ErrorMessage = "Este registro es demaciado corto")]
        public string Nit { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(7, ErrorMessage = "Este registro es demaciado corto")]
        public string Telefono { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

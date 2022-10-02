using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INVENNET.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(3, ErrorMessage = "Este registro es demaciado corto")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(5, ErrorMessage = "Este registro es demaciado corto")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(3, ErrorMessage = "Este registro es demaciado corto")]
        public string Marca { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 99, ErrorMessage = "Solo se permiten partidas maximas de 100 items.")]
        public int Existencia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int? IdProveedor { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int? IdCategoria { get; set; }
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        public int? IdUsuario { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual Proveedore? IdProveedorNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}

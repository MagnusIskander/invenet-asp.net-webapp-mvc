using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INVENNET.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Este registro es demaciado largo")]
        [MinLength(5, ErrorMessage = "Este registro es demaciado corto")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Total { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}

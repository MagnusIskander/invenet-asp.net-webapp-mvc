using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public String? Estado { get; set; }
        public string? Descripcion { get; set; }

        public int Total { get; set; }

        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}

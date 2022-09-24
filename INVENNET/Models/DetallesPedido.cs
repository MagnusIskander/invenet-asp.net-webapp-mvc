using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class DetallesPedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdProducto { get; set; }
        public int? IdPedido { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Pedido? IdPedidoNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}

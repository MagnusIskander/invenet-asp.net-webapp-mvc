using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Categoria = new HashSet<Categoria>();
            DetallesPedidos = new HashSet<DetallesPedido>();
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}

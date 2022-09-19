using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Marca { get; set; } = null!;
        public int Existencia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Precio { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual Proveedore? IdProveedorNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}

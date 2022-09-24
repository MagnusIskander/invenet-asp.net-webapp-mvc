using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

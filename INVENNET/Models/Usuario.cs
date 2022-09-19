using System;
using System.Collections.Generic;

namespace INVENNET.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime? Fecha { get; set; }
    }
}

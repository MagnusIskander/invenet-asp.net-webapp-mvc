using INVENNET.Models;


namespace INVENNET.Data
{
    public class DataLogic
    {
        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>()
            {
                new Usuario{Usuario1="Admin", Clave="admim", Nombres="Admin", Apellidos="Admin" },
                new Usuario{Usuario1="Alejandro", Clave="yo", Nombres="Alejandro", Apellidos="Osorio" },
                new Usuario{Usuario1="Ange", Clave="yo", Nombres="Angelica", Apellidos="Carvajal" }
            };
        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().FirstOrDefault(item => item.Usuario1 == _correo && item.Clave == _clave);
        }
    }
}

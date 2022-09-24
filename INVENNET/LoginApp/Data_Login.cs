using INVENNET.Controllers;
using INVENNET.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;


namespace INVENNET.LoginApp
{
    public class Data_Login
    {
        //public List<Usuario> ListaUsuario()
        private INVENETContext _context = new INVENETContext();
        private IEnumerable<Usuario> user { get; set; }

        public Usuario ValidateUser(string _nombre, string _password)
        {
            user = _context.Usuarios;
            return user.Where(item => item.Usuario1 == _nombre && item.Clave == _password).FirstOrDefault();
        }
    }
}

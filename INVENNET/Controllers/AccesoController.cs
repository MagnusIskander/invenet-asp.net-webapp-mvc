using Microsoft.AspNetCore.Mvc;
using INVENNET.Models;
using INVENNET.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace WWW.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DataLogic _da_usuario = new DataLogic();
            var usuario = _da_usuario.ValidarUsuario(_usuario.Usuario1, _usuario.Clave);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Usuario1),
                    new Claim("Usuario1", usuario.Usuario1)
                };


                /*foreach (string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }*/

                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
    }
}


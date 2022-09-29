using INVENNET.LoginApp;
using INVENNET.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace INVENNET.Controllers
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
            Data_Login _data_usuario = new Data_Login();
            var usuario = _data_usuario.ValidateUser(_usuario.Usuario1, _usuario.Clave);
            if (usuario != null)
            {
                Console.WriteLine(usuario.ToString());
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(usuario.Id)),
                    new Claim(ClaimTypes.Name, usuario.Usuario1),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                    //new Claim("Password", _usuario.Password)
                };
                /*Console.WriteLine(claims);
                string rol = usuario.Roles;  
                Console.WriteLine(rol);
                claims.Add);*/
                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                                          new ClaimsPrincipal(ClaimsIdentity),
                                                                          new AuthenticationProperties
                                                                          {
                                                                              ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                                                                              IsPersistent= true,
                                                                              AllowRefresh=true
                                                                          });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Password Incorrecto";
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

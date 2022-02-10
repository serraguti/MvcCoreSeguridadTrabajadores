using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadTrabajadores.Models;
using MvcCoreSeguridadTrabajadores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCoreSeguridadTrabajadores.Controllers
{
    public class ManageController : Controller
    {
        private RepositoryDoctores repo;

        public ManageController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login
            (string username, string password)
        {
            Doctor doctor =
                this.repo.ExisteDoctor(username, int.Parse(password));
            if (doctor != null)
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim
                    (new Claim(ClaimTypes.Name, doctor.Apellido));
                identity.AddClaim
                    (new Claim(ClaimTypes.NameIdentifier, doctor.IdDoctor.ToString()));
                ClaimsPrincipal user = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , user);
                string controller =
                    TempData["controller"].ToString();
                string action = TempData["action"].ToString();
                string id = TempData["id"].ToString();
                return RedirectToAction(action, controller
                    , new { id=id });
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}

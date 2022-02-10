using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadTrabajadores.Filters;
using MvcCoreSeguridadTrabajadores.Models;
using MvcCoreSeguridadTrabajadores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSeguridadTrabajadores.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryDoctores repo;

        public EnfermosController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetEnfermos());
        }

        [AuthorizeDoctores]
        public IActionResult Delete(string id)
        {
            Enfermo enfermo = this.repo.FindEnfermo(id);
            return View(enfermo);
        }

        [HttpPost]
        public IActionResult Delete(string id, string accion)
        {
            this.repo.DeleteEnfermo(id);
            return RedirectToAction("Index");
        }
    }
}

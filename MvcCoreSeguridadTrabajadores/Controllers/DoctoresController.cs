using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadTrabajadores.Filters;
using MvcCoreSeguridadTrabajadores.Models;
using MvcCoreSeguridadTrabajadores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace MvcCoreSeguridadTrabajadores.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [AuthorizeDoctores]
        public IActionResult PerfilDoctor()
        {
            string iddoctor =
                HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Doctor doc = this.repo.Finddoctor(int.Parse(iddoctor));
            return View(doc);
        }
    }
}

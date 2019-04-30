using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class VacinasController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;

        public VacinasController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            VacinaModel objVacina = new VacinaModel(HttpContextAccessor);
            ViewBag.ListaVacina = objVacina.ListaVacina();
            return View();
        }
        [HttpPost]
        public IActionResult CriarVacina(VacinaModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarVacina()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
         
            return View();
        }

    }
}
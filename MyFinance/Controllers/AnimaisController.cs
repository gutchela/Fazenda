using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class AnimaisController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;

        public AnimaisController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            AnimaisModel objAnimais = new AnimaisModel(HttpContextAccessor);
            ViewBag.ListaAnimais = objAnimais.ListaAnimais();
            return View();
        }
     
       
        [HttpPost]
        public IActionResult Cadastrar(AnimaisModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
               //formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }
        

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id != null)
            {
                AnimaisModel objAnimais = new AnimaisModel(HttpContextAccessor);
               // ViewBag.Registro = objAnimais.CarregarRegistro(id);
            }
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            ViewBag.ListaPlanoContas = new PlanoContaModel(HttpContextAccessor).ListaPlanoContas();

            return View();
        }



    }
}
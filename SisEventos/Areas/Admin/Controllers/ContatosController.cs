using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class ContatosController : BaseAdminController
    {
        public ContatosController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var contatos = db.Contatos.ToList();
            return View(contatos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contato contato = new Contato();
            return View(contato);
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contato);
        }
    }
}
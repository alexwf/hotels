using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class ContatosController : Controller
    {
        Banco db;

        public ContatosController(Banco db)
        {
            this.db = db;
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
                return RedirectToAction("Index", "Home");
            }

            return View(contato);
        }
    }
}
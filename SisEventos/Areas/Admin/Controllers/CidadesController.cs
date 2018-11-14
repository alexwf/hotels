using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class CidadesController : BaseAdminController
    {
        public CidadesController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var cidades = db.Cidades.ToList();
            return View(cidades);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Cidade cidade = new Cidade();
            return View(cidade);
        }

        [HttpPost]
        public IActionResult Create(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }
    }
}
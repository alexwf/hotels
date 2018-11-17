using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class GastronomiasController : BaseAdminController
    {
        public GastronomiasController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var gastronomias = db.Gastronomias.ToList();
            return View(gastronomias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Gastronomia gastronomia = new Gastronomia();
            return View(gastronomia);
        }

        [HttpPost]
        public IActionResult Create(Gastronomia gastronomia)
        {
            if (ModelState.IsValid)
            {
                db.Gastronomias.Add(gastronomia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gastronomia);
        }
    }
}
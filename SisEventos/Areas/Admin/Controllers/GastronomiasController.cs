using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;
using SisEventos.ViewModels;

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
            GastronomiaVM vm = new GastronomiaVM();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(GastronomiaVM vm)
        {
            if (ModelState.IsValid)
            {
                Gastronomia gastronomia = new Gastronomia();

                gastronomia.Nome = vm.Nome;
                this.db.Gastronomias.Add(gastronomia);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Gastronomia gastronomia = this.db.Gastronomias
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            GastronomiaVM vm = new GastronomiaVM();
            vm.Nome = gastronomia.Nome;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, GastronomiaVM vm)
        {
            if (ModelState.IsValid)
            {
                Gastronomia gastronomiaDb = this.db.Gastronomias.Find(id);
                gastronomiaDb.Nome = vm.Nome;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Gastronomia gastronomia = this.db.Gastronomias
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            return View(gastronomia);
        }

        [HttpPost]
        public IActionResult Delete(long id, Gastronomia gastronomia)
        {
            Gastronomia gastronomiaDb= this.db.Gastronomias
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Gastronomias.Remove(gastronomiaDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
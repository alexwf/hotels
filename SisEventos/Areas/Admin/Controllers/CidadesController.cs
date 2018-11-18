using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;
using SisEventos.ViewModels;

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
            CidadeVM vm = new CidadeVM();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CidadeVM vm)
        {
            if (ModelState.IsValid)
            {
                Cidade cidade = new Cidade();

                cidade.Nome = vm.Nome;
                this.db.Cidades.Add(cidade);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Cidade cidade = this.db.Cidades
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            CidadeVM vm = new CidadeVM();
            vm.Nome = cidade.Nome;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, CidadeVM vm)
        {
            if (ModelState.IsValid)
            {
                Cidade cidadeDb = this.db.Cidades.Find(id);
                cidadeDb.Nome = vm.Nome;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Cidade cidade = this.db.Cidades
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            return View(cidade);
        }

        [HttpPost]
        public IActionResult Delete(long id, Cidade cidade)
        {
            Cidade cidadeDb = this.db.Cidades
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Cidades.Remove(cidadeDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;
using SisEventos.ViewModels;

namespace SisEventos.Areas.Admin.Controllers
{
    public class SuitesController : BaseAdminController
    {
        public SuitesController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var suites = db.Suites.ToList();
            return View(suites);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SuiteVM vm = new SuiteVM();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(SuiteVM vm)
        {
            if (ModelState.IsValid)
            {
                Suite suite = new Suite();
                suite.Tipo = vm.Tipo;
                suite.QtCamaCasal = vm.QtCamaCasal;
                suite.QtCamaSolteiro = vm.QtCamaSolteiro;
                this.db.Suites.Add(suite);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Suite suite = this.db.Suites
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            SuiteVM vm = new SuiteVM();
            vm.Tipo = suite.Tipo;
            vm.QtCamaCasal = suite.QtCamaCasal;
            vm.QtCamaSolteiro = suite.QtCamaSolteiro;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, SuiteVM vm)
        {
            if (ModelState.IsValid)
            {
                Suite suiteDb = this.db.Suites.Find(id);
                suiteDb.Tipo = vm.Tipo;
                suiteDb.QtCamaCasal = vm.QtCamaCasal;
                suiteDb.QtCamaSolteiro = vm.QtCamaSolteiro;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Suite suite = this.db.Suites
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            return View(suite);
        }

        [HttpPost]
        public IActionResult Delete(long id, Suite suite)
        {
            Suite suiteDb = this.db.Suites
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Suites.Remove(suiteDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
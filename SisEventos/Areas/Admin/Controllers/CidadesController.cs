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
        public IActionResult Edit(long Id)
        {
            Cidade cidade = this.db.Cidades
                                    .Where(x => x.Id == Id)
                                    .FirstOrDefault();


            CidadeVM vm = new CidadeVM();
            //vm.Nome = Cidade.Nome;
        }

        [HttpPost]
        public IActionResult Edit(long Id, CidadeVM vm)
        {

        }
}
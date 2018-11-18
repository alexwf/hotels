using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;
using SisEventos.ViewModels;

namespace SisEventos.Areas.Admin.Controllers
{
    public class ContatosController : BaseAdminController
    {
        public ContatosController(Banco db) : base (db) { }

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
                return RedirectToAction("Index", "Home");
            }

            return View(contato);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            Contato contato = this.db.Contatos.Where(x => x.Id == Id).FirstOrDefault();

            if (contato == null)
            {
                return NotFound();
            }

            ContatoVM vm = new ContatoVM();
            vm.Nome = contato.Nome;
            vm.Email = contato.Email;
            vm.Mensagem = contato.Mensagem;
            vm.Telefone = contato.Telefone;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, ContatoVM vm)
        {
            if (ModelState.IsValid)
            {
                Contato contatoDb = this.db.Contatos.Find(id);
                contatoDb.Nome = vm.Nome;
                contatoDb.Email = vm.Email;
                contatoDb.Mensagem = vm.Mensagem;
                contatoDb.Telefone = vm.Telefone;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Contato contato = this.db.Contatos.Where(x => x.Id == id).FirstOrDefault();

            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Delete(long id, Contato contato)
        {
            Contato contatoDb = this.db.Contatos
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Contatos.Remove(contatoDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
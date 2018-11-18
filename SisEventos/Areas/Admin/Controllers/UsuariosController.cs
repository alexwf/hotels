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
    public class UsuariosController : BaseAdminController
    {
        public UsuariosController(Banco db) : base(db){ }

        public IActionResult Index()
        {
            var usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            UsuarioVM vm = new UsuarioVM();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(UsuarioVM vm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();

                usuario.Nome = vm.Nome;
                usuario.Email = vm.Email;
                usuario.Password = vm.Password;
                this.db.Usuarios.Add(usuario);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Usuario usuario = this.db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
            UsuarioVM vm = new UsuarioVM();
            vm.Nome = usuario.Nome;
            vm.Email = usuario.Email;
            vm.Password = usuario.Password;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioDb = this.db.Usuarios.Find(id);
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.Email = usuario.Email;
                usuarioDb.Password = usuario.Password;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Usuario usuario = this.db.Usuarios
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(long id, Usuario usuario)
        {
            Usuario usuarioDb = this.db.Usuarios
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Usuarios.Remove(usuarioDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
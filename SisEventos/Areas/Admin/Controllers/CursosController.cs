using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class CursosController : BaseAdminController
    {
        public CursosController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var cursos = db.Cursos.ToList();
            return View(cursos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Curso curso = new Curso();
            return View(curso);
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }
    }
}
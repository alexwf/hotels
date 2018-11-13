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
    public class HoteisController : BaseAdminController
    {
        
        private IHostingEnvironment env;

        private String UploadImagem(IFormFile formFile)
        {
            if(formFile != null && formFile.Length != 0)
            {
                string extension = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                var path = Path.Combine(env.WebRootPath, "hoteis", fileName).ToLower();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                return $"/hoteis/{fileName}";
            }

            return null;
        }

        public HoteisController(Banco _db, IHostingEnvironment _env): base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Hotel> hoteis = this.db.Hoteis.ToList();
            return View(hoteis);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HotelVM vm = new HotelVM();

            var cursos = db.Cursos.ToList();
            foreach(var curso in cursos)
            {
                vm.Cursos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(HotelVM vm)
        {
            if(ModelState.IsValid)
            {
                Hotel hotel = new Hotel();
                hotel.Nome = vm.Nome;
                hotel.Descricao = vm.Descricao;
                hotel.Preco = vm.Preco;
                hotel.CaminhoImagem = this.UploadImagem(vm.Imagem);
                hotel.Curso = db.Cursos.Find(vm.IdCursoSelecionado);
                this.db.Hoteis.Add(hotel);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cursos = db.Cursos.ToList();
            foreach (var curso in cursos)
            {
                vm.Cursos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }
            
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Hotel hotel = this.db.Hoteis
                                   .Include(m => m.Curso)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            if (hotel == null)
            {
                return NotFound();
            }

            HotelVM vm = new HotelVM();
            vm.Nome = hotel.Nome;
            vm.Descricao = hotel.Descricao;
            vm.Preco = hotel.Preco;
            var cursos = db.Cursos.ToList();
            foreach (var curso in cursos)
            {
                vm.Cursos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }
            vm.IdCursoSelecionado = hotel.Curso.Id;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, HotelVM vm)
        {
            if (ModelState.IsValid)
            {
                Hotel hotelDb = this.db.Hoteis.Find(id);
                hotelDb.Nome = vm.Nome;
                hotelDb.Descricao = vm.Descricao;
                hotelDb.Preco = vm.Preco;
                hotelDb.CaminhoImagem = this.UploadImagem(vm.Imagem);
                hotelDb.Curso = db.Cursos.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Hotel hotel = this.db.Hoteis
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Hotel hotel = this.db.Hoteis
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        public IActionResult Delete(long id, Hotel hotel)
        {
            Hotel hotelDb = this.db.Hoteis
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Hoteis.Remove(hotelDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
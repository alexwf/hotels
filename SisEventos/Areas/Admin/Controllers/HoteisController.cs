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

            var cidades = db.Cidades.ToList();
            foreach(var cidade in cidades)
            {
                vm.Cidades.Add(new SelectListItem
                {
                    Value = cidade.Id.ToString(),
                    Text = cidade.Nome
                });
            }

            var suites = db.Suites.ToList();
            foreach(var suite in suites)
            {
                vm.Suites.Add(new SelectListItem
                {
                    Value = suite.Id.ToString(),
                    Text = suite.Tipo
                });
            }

            var gastronomias = db.Gastronomias.ToList();
            foreach (var gastronomia in gastronomias)
            {
                vm.Gastronomias.Add(new SelectListItem
                {
                    Value = gastronomia.Id.ToString(),
                    Text = gastronomia.Nome
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
                hotel.Cidade = db.Cidades.Find(vm.IdCidadeSelecionada);
                hotel.Suite = db.Suites.Find(vm.IdSuiteSelecionada);
                hotel.Gastronomia = db.Gastronomias.Find(vm.IdGastronomiaSelecionada);
                this.db.Hoteis.Add(hotel);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cidades = db.Cidades.ToList();
            foreach (var cidade in cidades)
            {
                vm.Cidades.Add(new SelectListItem
                {
                    Value = cidade.Id.ToString(),
                    Text = cidade.Nome
                });
            }

            var suites = db.Suites.ToList();
            foreach (var suite in suites)
            {
                vm.Suites.Add(new SelectListItem
                {
                    Value = suite.Id.ToString(),
                    Text = suite.Tipo
                });
            }

            var gastronomias = db.Gastronomias.ToList();
            foreach (var gastronomia in gastronomias)
            {
                vm.Gastronomias.Add(new SelectListItem
                {
                    Value = gastronomia.Id.ToString(),
                    Text = gastronomia.Nome
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Hotel hotel = this.db.Hoteis
                                   .Include(m => m.Cidade)
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
            var cidades = db.Cidades.ToList();
            foreach (var cidade in cidades)
            {
                vm.Cidades.Add(new SelectListItem
                {
                    Value = cidade.Id.ToString(),
                    Text = cidade.Nome
                });
            }
            vm.IdCidadeSelecionada = hotel.Cidade.Id;

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
                hotelDb.Cidade = db.Cidades.Find(vm.IdCidadeSelecionada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Hotel hotel = this.db.Hoteis
                                  .Include(m => m.Cidade)
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
                                  .Include(m => m.Cidade)
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
                                  .Include(m => m.Cidade)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Hoteis.Remove(hotelDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
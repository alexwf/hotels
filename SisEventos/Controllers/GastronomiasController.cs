﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class GastronomiasController : Controller
    {

        private Banco db;

        public GastronomiasController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Gastronomia> gastronomias = db.Gastronomia.ToList();
            return View(gastronomias );
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Gastronomia gastronomia = this.db.Gastronomia
                                  .Include(m => m.Cidade)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (gastronomia == null)
            {
                return NotFound();
            }

            return View(gastronomia);
        }
    }
}
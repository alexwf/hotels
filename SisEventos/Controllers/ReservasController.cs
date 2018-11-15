using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class HoteisController : Controller
    {

        private Banco db;

        public HoteisController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Hotel> hoteis = db.Hoteis.ToList();
            return View(hoteis);
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
    }
}
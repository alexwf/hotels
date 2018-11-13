using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class EventosController : Controller
    {

        private Banco db;

        public EventosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Evento> eventos = db.Eventos.ToList();
            return View(eventos);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Evento evento = this.db.Eventos
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }
    }
}
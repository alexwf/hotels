using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class ReservasController : BaseAdminController
    {
        public ReservasController(Banco db) : base(db) { }

        public IActionResult Index()
        {
            var reservas = db.Reservas.ToList();
            return View(reservas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Reserva reserva = new Reserva();
            return View(reserva);
        }

        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserva);
        }
    }
}
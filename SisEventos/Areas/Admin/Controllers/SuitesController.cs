using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class SuitesController : Controller
    {

        private Banco db;

        public SuitesController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Suite> suites = db.Suites.ToList();
            return View(suites);
        }
    }
}
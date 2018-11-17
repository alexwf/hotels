using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class ContatosController : Controller
    {

        private Banco db;

        public ContatosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Contato> contatos = db.Contatos.ToList();
 
            return View(contatos);
        }
    }
}
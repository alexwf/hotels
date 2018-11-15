using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class UsuariosController : Controller
    {

        private Banco db;

        public UsuariosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Usuario usuario = this.db.Usuarios
                                  .Include(m => m.Cidade)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
    }
}
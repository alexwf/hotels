using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Filters;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public HomeController(Banco _db) : base(_db) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
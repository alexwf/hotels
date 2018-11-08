using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Filters;
using SisEventos.Models;

namespace SisEventos.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(AuthVerification))]
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
        protected Banco db;

        public BaseAdminController(Banco _db)
        {
            this.db = _db;
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SisEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Filters
{
    public class UserInfoFilter : IActionFilter
    {
        private Banco db;
        public UserInfoFilter(Banco _db)
        {
            this.db = _db;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var auth_token = request.Cookies[Usuario.COOKIE_AUTH_TOKEN_NAME];
            var usuario = db.Usuarios
                            .Where(m => m.AuthToken.Equals(auth_token))
                            .FirstOrDefault();
            if(usuario != null)
            {
                var controller = context.Controller as Controller;
                controller.ViewBag.User = usuario;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using SisEventos.Controllers;
using SisEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Filters
{
    public class AuthVerification : ActionFilterAttribute
    {
        private Banco db;

        public AuthVerification(Banco _db)
        {
            this.db = _db;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var request = context.HttpContext.Request;
            var auth_token = request.Cookies[Usuario.COOKIE_AUTH_TOKEN_NAME];
            var usuario = db.Usuarios
                            .Where(m => m.AuthToken.Equals(auth_token))
                            .FirstOrDefault();
            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "area", "" },
                    { "controller", "Auth" },
                    { "action", "AcessoNegado" }
                });
            }
            else
            {
                var controller = context.Controller as Controller;
                controller.ViewBag.User = usuario;
            }
        }
    }
}

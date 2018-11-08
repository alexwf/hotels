using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;
using SisEventos.ViewModels;

namespace SisEventos.Controllers
{
    public class AuthController : Controller
    {

        private Banco db;

        public AuthController(Banco _db)
        {
            this.db = _db;
        }

        private void CriaAdminSeNaoExistir()
        {
            if(this.db.Usuarios.Count() == 0)
            {
                Usuario admin = new Usuario();
                admin.Email = "admin@admin.com";
                admin.Password = Usuario.GenerateHash("123");
                admin.Nome = "Administrador";
                db.Usuarios.Add(admin);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            CriaAdminSeNaoExistir();
            LoginVM vm = new LoginVM();
            return View(vm);
        }


        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.Usuarios
                                .Where(m => m.Email.ToLower().Equals(vm.Email.ToLower()))
                                .FirstOrDefault();
                if(usuario == null)
                {
                    ModelState.AddModelError("Email", "Usuário não encontrado");
                    return View(vm);
                }

                string vmPasswordHash = Usuario.GenerateHash(vm.Password);

                if (usuario.Password.Equals(vmPasswordHash))
                {
                    usuario.AuthToken = Usuario.GenerateAuthToken();
                    db.SaveChanges();
                    Response.Cookies.Append(Usuario.COOKIE_AUTH_TOKEN_NAME, usuario.AuthToken);
                    return RedirectToRoute(new { controller="Home", action="Index" });
                }
                else
                {
                    ModelState.AddModelError("Password", "Senha incorreta");
                    return View(vm);
                }
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            var authToken = Request.Cookies[Usuario.COOKIE_AUTH_TOKEN_NAME];
            if(authToken != null)
            {
                var usuario = db.Usuarios
                                .Where(m => m.AuthToken == authToken)
                                .FirstOrDefault();
                usuario.AuthToken = "";
                db.SaveChanges();
            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            SignUpVM vm = new SignUpVM();
            return View(vm);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpVM vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.Password != vm.PasswordConfirm)
                {
                    ModelState.AddModelError("PasswordConfirm", "As senhas informadas não são iguais");
                    return View(vm);
                }


                Usuario usuario = new Usuario();
                usuario.Nome = vm.Nome;
                usuario.Email = vm.Email;
                usuario.Password = Usuario.GenerateHash(vm.Password);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult AcessoNegado()
        {
            return View();
        }

    }
}
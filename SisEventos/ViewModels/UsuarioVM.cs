using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SisEventos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.ViewModels
{
    public class UsuarioVM
    {
        public UsuarioVM()
        {

        }
        
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Usuario")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "O Nome deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        [Display(Name = "E-mail do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}

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
    public class CidadeVM
    {
        public CidadeVM()
        {

        }
        
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da cidade")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "O Nome deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }
    }
}

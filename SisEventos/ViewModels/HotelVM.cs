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
    public class HotelVM
    {
        public HotelVM()
        {
            this.Cursos = new List<SelectListItem>();
        }
        
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do hotel")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "O Nome deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Nome do hotel")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do hotel")]
        [Display(Name = "Descrição do hotel")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço da diária")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem de capa")]
        public IFormFile Imagem { get; set; }

        public List<SelectListItem> Cursos { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Informe o curso do evento")]
        public long IdCursoSelecionado { get; set; }
    }
}

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
            this.Cidades = new List<SelectListItem>();
            this.Suites = new List<SelectListItem>();
            this.Gastronomias = new List<SelectListItem>();
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

        public List<SelectListItem> Cidades { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe a cidade")]
        public long IdCidadeSelecionada { get; set; }

        public List<SelectListItem> Suites { get; set; }

        [Display(Name = "Suítes")]
        [Required(ErrorMessage = "Informe a suíte")]
        public long IdSuiteSelecionada { get; set; }

        public List<SelectListItem> Gastronomias { get; set; }

        [Display(Name = "Gastronomia")]
        [Required(ErrorMessage = "Informe o prato")]
        public long IdGastronomiaSelecionada { get; set; }
    }
}

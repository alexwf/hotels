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
    public class SuiteVM
    {
        public SuiteVM()
        {

        }
        
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o tipo de suíte")]
        [Display(Name = "Tipo")]
        public String Tipo { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de camas de casal")]
        [Display(Name = "Quantidade de camas de casal")]
        public Int16 QtCamaCasal { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de camas de solteiro")]
        [Display(Name = "Quantidade de camas de solteiro")]
        public Int16 QtCamaSolteiro { get; set; }
    }
}

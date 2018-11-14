using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Suite
    {
        public long Id { get; set; }

        [Display(Name = "Tipo")]
        public String Tipo { get; set; }

        [Display(Name = "Quantidade de camas de casal")]
        public Int16 QtCamaCasal { get; set; }

        [Display(Name = "Quantidade de camas de solteiro")]
        public Int16 QtCamaSolteiro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Gastronomia
    {
        public long Id { get; set; }

        [Display(Name = "Nome")]
        public String Nome { get; set; }
    }
}

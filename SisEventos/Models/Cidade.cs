﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Cidade
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da cidade")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}

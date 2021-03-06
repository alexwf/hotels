﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Hotel
    {
        public long Id { get; set; }

        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Display(Name = "Descrição do hotel")]
        public String Descricao { get; set; }

        [Display(Name = "Imagem do hotel")]
        public String CaminhoImagem { get; set; }

        [Display(Name = "Preço da diária")]
        public Decimal Preco { get; set; }

        [Display(Name = "Cidade")]
        public virtual Cidade Cidade { get; set; }

        [Display(Name = "Suite")]
        public virtual Suite Suite { get; set; }

        [Display(Name = "Gastronomia")]
        public virtual Gastronomia Gastronomia { get; set; }

    }
}

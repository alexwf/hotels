using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Contato
    {
        public long Id { get; set; }

        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Display(Name = "Telefone")]
        public String Telefone { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Mensagem")]
        public String Mensagem { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Usuario
    {
        public static string COOKIE_AUTH_TOKEN_NAME = "auth_token";

        public long Id { get; set; }

        public string AuthToken { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o seu nome")]
        public String Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe o seu email")]
        public String Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a sua senha")]
        public String Password { get; set; }


        public static String GenerateHash(String password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
            return Encoding.Unicode.GetString(hash);
        }

        public static String GenerateAuthToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

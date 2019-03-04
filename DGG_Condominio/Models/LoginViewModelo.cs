using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class LoginViewModelo
    {

        [Key]
        public int Usu_Cod { get; internal set; }

        public string Usu_Unome { get; internal set; }

        [Required] //Obriga preenchimento
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // Muda o texto para *****
        public string Senha { get; set; }

        [Display(Name = "Lembre-me")]
        public bool RememberMe { get; set; }
        public ClaimsIdentity Username { get; internal set; }


    }

}

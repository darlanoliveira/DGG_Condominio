using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{
    public class LoginDAO
    {
        private static CondominioContext context;

      

        public static dynamic BuscaUsuario (string email)        
        {
            IList < UsuariosModelos > usuario = context.usuarios.Where(u => u.USU_LOGIN == email).ToList();
            return usuario;
        }

    }
}

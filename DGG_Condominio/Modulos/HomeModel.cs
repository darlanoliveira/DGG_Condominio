using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{
    public class HomeModel
    {
        public static dynamic BuscaUsuario(string email, string senha)
        {       
            using (var repo = new CondominioContext())
            {
                IList<UsuariosModelos> usuario = repo.usuarios.Where(u => u.USU_LOGIN.Equals(email) && u.USU_SENHA.Equals(senha)).ToList();
                if (usuario.Any())
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
                
            }
        }

    }
}

using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{
    public class LoginDAO: ILoginDAO, IDisposable
    {
        public static CondominioContext context;

       

        public static dynamic BuscaUsuario (string email)        
        {
            try
            {
                IList<UsuariosModelos> usuario = context.usuarios.Where(u => u.USU_LOGIN == email).ToList();
                return usuario;
            }
            catch (SqlException sqlEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<UsuariosModelos> produtos()
        {
            throw new NotImplementedException();
        }
    }
}

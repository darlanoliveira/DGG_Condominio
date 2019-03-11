using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{

    public class HomeModel
    {
        private static int _usuarioCodigo;
        public static dynamic BuscaUsuario(string email, string senha)
        {
            using (var repo = new CondominioContext())
            {
                IList<UsuariosModelos> usuario = repo.usuarios.Where(u => u.USU_LOGIN.Equals(email) && u.USU_SENHA.Equals(senha)).ToList();
                if (usuario.Any())
                {
                    foreach (var item in usuario)
                    {
                        _usuarioCodigo = item.USU_COD;
                    }
                    return usuario;
                }
                else
                {
                    return null;
                }

            }
        }
        public static dynamic AtualUsuario()
        {
            using (var repo = new CondominioContext())
            {
                IList<UsuariosModelos> usuarioAtual = repo.usuarios.Where(u => u.USU_COD.Equals(_usuarioCodigo)).ToList();
                if (usuarioAtual.Any())
                {
                    return usuarioAtual;
                }
                else
                {
                    return null;
                }

            }
        }




    //---------Métodos da tela "Condominios"------------//
    public static string  SalvarMensagem(string titulo, string texto, int usu_cad)
        {

            MensagensModelo msg = new MensagensModelo();
            msg.MSG_USU_COD = usu_cad;
            msg.MSG_USU_CAD = usu_cad;
            msg.MSG_TITULO = titulo;
            msg.MSG_TEXTO = texto;
            msg.MSG_STATUS = "Pendente";
            msg.MSG_DATA = DateTime.Now;
            msg.MSG_APTO = "0";
            msg.MSG_BLOCO = "0";

            using (var repo = new CondominioContext())
            {
                repo.mensagens.Add(msg);
                repo.SaveChanges();
            }


                return null;
        }

    }
}

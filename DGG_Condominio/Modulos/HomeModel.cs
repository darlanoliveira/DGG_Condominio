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

        public static dynamic DadosUsuario(string inf,string id)//inf = o que você está procurando, ID login do usuário, existe um método no controller chamado "iduser()" que busca essa informação;
        {
            
            using (var repo = new CondominioContext())
            {
                IList<UsuariosModelos> usuarioAtual = repo.usuarios.Where(u => u.USU_LOGIN.Equals(id)).ToList();

                switch (inf)
                {
                    case "USU_COD":
                        return usuarioAtual[0].USU_COD;                      
                    case "USU_NOME":
                        return usuarioAtual[0].USU_NOME;
                    case "USU_LOGIN":
                        return usuarioAtual[0].USU_LOGIN;
                    case "USU_BLOCO":
                        return usuarioAtual[0].USU_BLOCO;
                    case "USU_APTO":
                        return usuarioAtual[0].USU_APTO;
                    case "USU_FOTO":
                        return usuarioAtual[0].USU_FOTO;
                    case "USU_NIVEL":
                        return usuarioAtual[0].USU_NIVEL;
                }
                return null;
                   
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

        public static string SalvarEncomenda(string bloco, string apto, int tipo, string rastreio, DateTime recebimento, DateTime retirada,int usuario)
            {

            using (var repo = new CondominioContext()) // Verifica se já tem uma encomenda com esse número de rastreio
            {
                IList<EncomendasModelo> encomenda = repo.encomendas.Where(e => e.ENC_RASTREIO.Equals(rastreio)).ToList();
                if (encomenda.Any() && retirada == DateTime.MinValue)
                {
                    return "Já existe uma encomenda com esse número de rastreio";
                }
                if(encomenda.Any() && retirada != DateTime.MinValue)
                {
                    using (var repoUp = new CondominioContext())
                    {
                        EncomendasModelo e = repoUp.encomendas.First(r => r.ENC_RASTREIO == rastreio); // Update na data retirada
                        e.ENC_DATARET = retirada;
                        e.ENC_STATUS = 1;
                        repoUp.SaveChanges();
                        return "Atualizado com Sucesso!";
                    }
                }
                
            }

            EncomendasModelo enc = new EncomendasModelo();
            enc.ENC_USU_CAD = usuario;
            enc.ENC_USU_COD = BuscarUsuarioMorador(apto,bloco);
            enc.ENC_BLOCO = bloco;
            enc.ENC_APTO = apto;
            enc.ENC_TIPO = tipo;
            enc.ENC_RASTREIO = rastreio;
            enc.ENC_DATA = recebimento;
            enc.ENC_DATARET = retirada;
           
            using (var repo = new CondominioContext()) // Salva uma nova encomenda
            {
                repo.encomendas.Add(enc);
                repo.SaveChanges();
                return "Salvo com Sucesso!";
            }


            return null;
        }

        public static List<EncomendasModelo> BuscarEncomendas(string rastreio)
        {
            using (var repo = new CondominioContext()) 
            {
               IList<EncomendasModelo> encomenda = repo.encomendas.Where(e => e.ENC_RASTREIO.Equals(rastreio)).ToList();
                return encomenda.ToList();
            } 

            return null;
        }

        public static string SalvarEnvPac(string bloco, string apto, string nome, DateTime recebimento,int usuario)
        {
            if(recebimento == DateTime.MinValue)
            {
                recebimento = DateTime.Now;
            }
            using (var repo = new CondominioContext())
            {
                IList<PortariaModelo> env = repo.portaria.Where(p => p.PORT_APTO == apto && p.PORT_BLOCO == bloco).ToList();
                if (env.Any())
                {
                    PortariaModelo p = repo.portaria.First(u => u.PORT_APTO == apto && u.PORT_BLOCO == bloco);
                    p.PORT_STATUS = 1;
                    repo.SaveChanges();
                    return "Salvo com Sucesso";
                }
                else
                {
                    PortariaModelo port = new PortariaModelo();
                    port.PORT_USU_CAD = usuario;
                    port.PORT_USU_COD = BuscarUsuarioMorador(apto,bloco);
                    port.PORT_APTO = apto;
                    port.PORT_STATUS = 1;
                    port.PORT_NOME = nome;
                    port.PORT_DATA = recebimento;
                    port.PORT_BLOCO = bloco;

                    repo.Add(port);
                    repo.SaveChanges();
                    return "Salvo com Sucesso";
                }
            }

                return null;
        }
       
        public static int BuscarUsuarioMorador(string apto, string bloco) // Buscar o usu_cod do primeiro usuário cadastrado para aquele apto
        {
            using (var repo = new CondominioContext())
            {
                UsuariosModelos usu = repo.usuarios.Where(u => u.USU_APTO == apto && u.USU_BLOCO == bloco && u.USU_RESP == 1).OrderBy(u => u.USU_COD).First();
                return usu.USU_COD;
            }

                return 0;
        }

        public static string SalvarAvisoGeral(string aviso, DateTime data)
        {
            using (var repo = new CondominioContext())
            {
                AvisosModelo avi = new AvisosModelo();
                avi.AVI_TEXTO = aviso;
                avi.AVI_DATA = data;

                repo.avisos.Add(avi);
                repo.SaveChanges();
                return "Salvo com Sucesso";
            }
        }

        public static List<AreasComunsModelo> BuscaAreasComuns() 
        {
            using (var repo = new CondominioContext())
            {
               IList< AreasComunsModelo> areasComuns = repo.areas_comuns.Where(a => a.ACO_ATIVO == 1).ToList();
                return areasComuns.ToList();
            }

            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGG_Condominio.Models;

namespace DGG_Condominio.Modulos
{
    public class ConfiguracaoDAO : IConfiguracao, IDisposable
    {
        private CondominioContext contexto;

        public void Adicionar(ConfiguracaoModelo c)
        {
            contexto.Add(c);
            contexto.SaveChanges();
        }

        public void Atualizar(ConfiguracaoModelo c)
        {
            contexto.Update(c);
            contexto.SaveChanges();
        }

        public void Remover(ConfiguracaoModelo c)
        {
            contexto.Remove(c);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
        public IList<ConfiguracaoModelo> configuracao()
        {
            return contexto.configuracao.ToList();           
        }        
    }
}

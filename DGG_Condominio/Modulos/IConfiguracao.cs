using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{
    interface IConfiguracao
    {
        void Adicionar(ConfiguracaoModelo c);
        void Atualizar(ConfiguracaoModelo c);
        void Remover(ConfiguracaoModelo c);
        IList<ConfiguracaoModelo> configuracao();
    }
}

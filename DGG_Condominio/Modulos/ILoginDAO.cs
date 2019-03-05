using DGG_Condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Modulos
{
    interface ILoginDAO
    {
       
        IList<UsuariosModelos> produtos();
    }
}

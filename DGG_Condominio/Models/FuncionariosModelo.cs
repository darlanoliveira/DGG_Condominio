using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class FuncionariosModelo
    {
        [key]
        public int FUNC_COD { get; internal set; }
        public int FUNC_USU_COD { get; internal set; }
        public int FUNC_NOME { get; internal set; }
        public int FUNC_FUNCAO { get; internal set; }
        public int FUNC_ENDERECO { get; internal set; }
        public int FUNC_TELEFONE { get; internal set; }
        public int FUNC_EMAIL { get; internal set; }
        public int FUNC_SALARIO { get; internal set; }
        public int FUNC_TRANSPORTE { get; internal set; }
        public int FUNC_REFEICAO { get; internal set; }
    }
}

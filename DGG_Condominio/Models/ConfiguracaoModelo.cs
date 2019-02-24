using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class ConfiguracaoModelo
    {
        public int CONFIG_COD { get; internal set; }
        public string CONFIG_CONDOMINIO { get; internal set; }
        public string CONFIG_BLOCO { get; internal set; }
        public string CONFIG_APTO { get; internal set; }
        public string CONFIG_VAGA { get; internal set; }
        public string CONFIG_TIPOMORA { get; internal set; }
        public string CONFIG_SITUACAOMORA { get; internal set; }
        public string CONFIG_CORREIO { get; internal set; }
        public string CONFIG_AREACOMUM { get; internal set; }
        public string CONFIG_VALORAREA { get; internal set; }
        public string CONFIG_DIASANTEC { get; internal set; }
    }
}

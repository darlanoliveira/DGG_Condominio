using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class MensagensModelo
    {
        [key]
        public int MSG_COD { get; internal set; }
        public int MSG_USU_COD { get; internal set; }
        public int MSG_USU_CAD { get; internal set; }
        public string MSG_TITULO { get; internal set; }
        public string MSG_TEXTO { get; internal set; }
        public DateTime MSG_DATA { get; internal set; }
        public string MSG_STATUS { get; internal set; }
        public string MSG_BLOCO { get; internal set; }
        public string MSG_APTO { get; internal set; }


    }
}

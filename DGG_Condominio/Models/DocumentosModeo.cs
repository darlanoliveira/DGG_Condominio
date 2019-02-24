using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class DocumentosModeo
    {
        [key]
        public int DOC_COD { get; internal set; }
        public string DOC_NOME { get; internal set; }
        public DateTime DOC_DATA { get; internal set; }
        public byte[] DOC_ARQUIVO { get; internal set; }
        public string DOC_TEXTO { get; internal set; }
    }
}

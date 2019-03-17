using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class PortariaModelo
    {
        [Key]
        public int PORT_COD { get; internal set; }
        public int PORT_USU_COD { get; internal set; }
        public int PORT_USU_CAD { get; internal set; }
        public string PORT_NOME { get; internal set; }
        public string PORT_BLOCO { get; internal set; }
        public string PORT_APTO { get; internal set; }
        public DateTime PORT_DATA { get; internal set; }
        public int PORT_STATUS { get; internal set; }
    }
}

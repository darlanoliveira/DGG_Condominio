using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class EncomendasModelo
    {
        [Key]
        public int ENC_COD { get; internal set; }
        public int ENC_USU_COD { get; internal set; }
        public int ENC_USU_CAD { get; internal set; }
        public int ENC_TIPO { get; internal set; }
        public DateTime ENC_DATA { get; internal set; }
        public int ENC_STATUS { get; internal set; }
        public string ENC_BLOCO { get; internal set; }
        public string ENC_APTO { get; internal set; }
        public string ENC_RASTREIO { get; internal set; }
        public DateTime ENC_DATARET { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class ReservasModelo
    {
        [Key]
        public int RES_COD { get; internal set; }
        public int RES_USU_COD { get; internal set; }
        public int RES_USU_CAD { get; internal set; }
        public int RED_TIPO { get; internal set; }
        public DateTime RES_DATA { get; internal set; }
        public int RES_STATUS { get; internal set; }
        public string RES_OBS { get; internal set; }
        public string RES_BLOCO { get; internal set; }
        public string RES_APTO { get; internal set; }
    }
}

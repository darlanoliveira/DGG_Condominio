using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class AvisosModelo
    {
        [Key]
        public int AVI_COD { get; internal set; }
        public string AVI_TEXTO { get; internal set; }
        public DateTime AVI_DATA { get; internal set; }
    }
}

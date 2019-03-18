using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class AreasComunsModelo
    {
        [Key]
        public int ACO_COD { get; internal set; }
        public string ACO_TIPO { get; internal set; }
        public int ACO_ATIVO { get; internal set; }
    }
}
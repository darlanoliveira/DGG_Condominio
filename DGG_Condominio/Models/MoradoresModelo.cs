using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class MoradoresModelo
    {
        [Key]
        public int MOR_COD { get; internal set; }
        public int MOR_USU_COD { get; internal set; }
        public string MOR_NOME { get; internal set; }
        public int MOR_TIPO { get; internal set; }
        public string MOR_TELEFONE { get; internal set; }
        public string MOR_CELULAR { get; internal set; }
        public string MOR_EMAIL { get; internal set; }
        public string MOR_VEICULO { get; internal set; }
        public string MOR_PLACA { get; internal set; }
        public string MOR_BLOCO { get; internal set; }
        public string MOR_APTO { get; internal set; }
        public string MOR_NUM_TAG { get; internal set; }
        public string MOR_NUM_VAGA { get; internal set; }
        public DateTime MOR_DATA_CAD_VAGA { get; internal set; }
        public string MOR_NUM_NOVA_VAGA { get; internal set; }
        public string MOR_OBS { get; internal set; }
        public string MOR_SITUACAO { get; internal set; }
        public DateTime MOR_NUM_DATA { get; internal set; }
    }
}

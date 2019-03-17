using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGG_Condominio.Models
{
    public class UsuariosModelos
    {
        [Key]
        public int USU_COD { get; internal set; }
        public string USU_NOME { get; internal set; }
        public string USU_LOGIN { get; internal set; }
        public string USU_SENHA { get; internal set; }
        public byte[] USU_FOTO { get; internal set; }
        public int USU_NIVEL { get; internal set; }
        public string USU_BLOCO { get; internal set; }
        public string USU_APTO { get; internal set; }
        public int USU_RESP { get; internal set; }

    }
}

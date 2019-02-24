using System;

namespace DGG_Condominio.Models
{
    public class ErrorViewModelo
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace OFICINA.Models
{
    public partial class Orcamento
    {
        public int CodCliente { get; set; }
        public DateTime DataOrcamento { get; set; }
        public string DescricaoOrcamento { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorOrcado { get; set; }
        public string Vendedor { get; set; }
    }
}

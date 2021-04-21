using System;
using System.ComponentModel.DataAnnotations;

namespace OFICINA
{
    public class AlterarOrcamentoRequest
    {
        public DateTime DataOrcamento { get; set; }
        public string NomeCliente { get; set; }
        public string Descricao { get; set; }
        public decimal ValorOrcado { get; set; }
        public string Vendedor { get; set; }
        public int CodCliente { get; set; }
    }
}


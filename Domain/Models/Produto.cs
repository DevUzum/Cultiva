using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    //Nome do Produto, Quantidade, Data de Colheita, Data de Validade, Produto de Troca, Data e Hora de Disponibilidade
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataColheita { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }
        public string ProdutoTroca { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataDisponibilidade { get; set; }
        public int? UsuarioId { get; set; } //M:1
        public Usuario Usuario { get; set; }
    }
}

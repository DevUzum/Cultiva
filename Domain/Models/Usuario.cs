using System;
using System.Collections.Generic;

namespace Domain.Models
{
    //Nome, Data de Nascimento, E-mail, RG, Telefone de Contato, Endereço de Moradia e Senha de Acesso
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; } //Relacionamento 1:1
        public string Senha { get; set; }
        public List<Produto> Produto { get; set; }
    }
}

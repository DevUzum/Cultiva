using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void CadastrarProduto(Produto produto);
        List<Produto> ListarProduto();
        List<Produto> ListarProdutoPor(Expression<Func<Produto, bool>> filtro);
        void RemoverProduto(int id);
        void EditarProduto(Produto produto);
        void SalvarProduto();
        List<Produto> ObterProdutosPorUsuarioId(int usuarioId);
        Produto BuscarPorId(int? id);
    }
}

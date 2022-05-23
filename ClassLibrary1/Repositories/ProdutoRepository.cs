using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private CultivaContext _context;
        public ProdutoRepository(CultivaContext context)
        {
            _context = context;
        }
        public void CadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public Produto BuscarPorId(int? id)
        {
           return _context.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void EditarProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public List<Produto> ListarProduto()
        {
            return _context.Produtos.ToList();
        }

        public List<Produto> ListarProdutoPor(Expression<Func<Produto, bool>> filtro)
        {
            return _context.Produtos.Where(filtro).ToList();
        }

        public void RemoverProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
        }

        public void SalvarProduto()
        {
            _context.SaveChanges();
        }

        public List<Produto> ObterProdutosPorUsuarioId(int usuarioId)
        {
            return _context.Produtos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public int MyProperty { get; set; }

    }
}

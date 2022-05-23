using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Fiap.GlobalImpact.Shared;
using Microsoft.AspNetCore.Mvc;

//Esta controller tem como objetivo realizar o CRUD da entidade Produto.
namespace Fiap.GlobalImpact.Controllers
{
    public class ProdutoController : ContextCultivaController
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View("CadastrarProduto");
        }

        [HttpGet]
        public IActionResult CadastrarProduto()
        {
            TempData["flag"] = false;
            var viewModel = new ProdutoViewModel()
            {
                Lista = _produtoRepository.ObterProdutosPorUsuarioId(ObterUsuarioLogado().Id)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            produto.UsuarioId = ObterUsuarioLogado().Id;
            _produtoRepository.CadastrarProduto(produto);
            _produtoRepository.SalvarProduto();
            return RedirectToAction("CadastrarProduto");
        }

        [HttpPost]
        public IActionResult RemoverProduto(int id)
        {
            _produtoRepository.RemoverProduto(id);
            _produtoRepository.SalvarProduto();
            return RedirectToAction("CadastrarProduto");
        }

        [HttpGet]
        public IActionResult EditarProduto(int? id)
        {
            TempData["flag"] = "true";
            var viewModel = new ProdutoViewModel()
            {
                Lista = _produtoRepository.ObterProdutosPorUsuarioId(ObterUsuarioLogado().Id)
            };
            viewModel.Produto = _produtoRepository.BuscarPorId(id);
            return View("CadastrarProduto", viewModel);
        }

        //TODO: Fazer uma página nova para editar produtos ou não rs
        [HttpPost]
        public IActionResult Atualizar(Produto produto)
        {
            TempData["flag"] = false;
            produto.UsuarioId = ObterUsuarioLogado().Id;
            _produtoRepository.EditarProduto(produto);
            _produtoRepository.SalvarProduto();
            return RedirectToAction("CadastrarProduto");
        }    
    }
}

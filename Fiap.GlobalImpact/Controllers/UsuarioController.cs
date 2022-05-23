using Domain.Interfaces;
using Domain.Models;
using Fiap.GlobalImpact.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text;

//Esta controller tem como objetivo realizar o cadastro do usuário e garantir a ação de logar
namespace Fiap.GlobalImpact.Controllers
{
    public class UsuarioController : ContextCultivaController
    {
        private IUsuarioRepository _usuarioRepository;
        private IProdutoRepository _produtoRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Retorna o formulário de cadastro de usuário
        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        //Realiza o cadastro do usuário
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            _usuarioRepository.CadastrarUsuario(usuario);
            _usuarioRepository.SalvarUsuario();
            return RedirectToAction("Index", "Home");
        }

        //Carrega uma página de login
        [HttpGet]
        public IActionResult ValidarUsuario()
        {
            return View();
        }

        //Validar se o usuário existe
        [HttpPost]
        public IActionResult ValidarUsuario(Usuario usuario)
        {
            //Método que valida se a conta existe
            var usuarioLogado = _usuarioRepository.ObterUsuario(usuario);

            //Se true: entra na conta | false retorna uma mensagem de erro.
            if (usuarioLogado != null)
            {
                //Cria uma sessão: Cada usuário que passar neste fluxo ele cria uma sessão. (60 minutos de vida)
                HttpContext.Session.Set("Cache", Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogado)));
                return RedirectToAction("UsuarioLogado");
            }
            TempData["msg"] = "Acesso Negado!";
            return RedirectToAction("ValidarUsuario");
        }

        //Abre o saguão principal
        //Criar um if | Se o usuário tem um certo atributo ele pode ficar logado | Senão ele volta pra tela de login
        [HttpGet]
        public IActionResult UsuarioLogado()
        {
            //Converte para string > Converte para Json > Objeto Complexo
            try
            {
                var usuarioLogado = ObterUsuarioLogado();
                TempData["NomeUsuario"] = usuarioLogado.Nome;
                return View(_produtoRepository.ListarProduto());
            }
            catch (System.Exception)
            {
                return View("ValidarUsuario");
            }
        }
    }
}

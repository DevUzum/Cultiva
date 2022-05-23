using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Fiap.GlobalImpact.Shared
{
    public class ContextCultivaController : Controller
    {
        public Usuario ObterUsuarioLogado()
        {
            //Retorna um byte array
            HttpContext.Session.TryGetValue("Cache", out var usuarioLogadoBytes);
            //Converte para string > Converte para Json > Objeto Complexo
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(Encoding.UTF8.GetString(usuarioLogadoBytes));
        }
    }
}

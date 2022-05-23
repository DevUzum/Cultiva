using Domain.Interfaces;
using System.Linq;

namespace Application.Services
{
    public class UsuarioServices
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidarLogin(string email, string senha)
        {
            var logins = _usuarioRepository.ListarUsuario();
            var validador = logins.Any(x => x.Email == email && x.Senha == senha);
            return validador;
        }
    }
}

using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario usuario);
        IList<Usuario> ListarUsuario();
        void SalvarUsuario();
        Usuario ObterUsuario(Usuario usuario);
    }
}

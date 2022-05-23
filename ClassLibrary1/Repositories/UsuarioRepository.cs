using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private CultivaContext _context;
        public UsuarioRepository(CultivaContext context)
        {
            _context = context;
        }
        public void CadastrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> ListarUsuario()
        {
            return _context.Usuarios.ToList();
        }

        public void SalvarUsuario()
        {
            _context.SaveChanges();
        }

        public Usuario ObterUsuario(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(f => 
                f.Email == usuario.Email && f.Senha == usuario.Senha);
        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CultivaContext : DbContext
    {
        public CultivaContext(DbContextOptions options) : base(options){ }

        //Tabelas - Entidades
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}

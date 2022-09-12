using GerenciadorDeLivrosLidos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeLivrosLidos.Data
{
    public class GerenciadorContext : DbContext
    {
        public GerenciadorContext(DbContextOptions<GerenciadorContext> options)
           : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }

    }
}

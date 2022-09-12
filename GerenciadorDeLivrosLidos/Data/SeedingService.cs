using GerenciadorDeLivrosLidos.Models;

namespace GerenciadorDeLivrosLidos.Data
{
    public class SeedingService

    {
        private GerenciadorContext _context;

        public SeedingService()
        {
        }

        public SeedingService(GerenciadorContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //if (_context.Livros.Any() ||
            //    _context.Autores.Any())
            //{
            //    return; 
            //}

            Autor a1 = new(1, "Jane Austen");
            Autor a2 = new(2, "Antoine de Saint-Exupéry");
            Autor a3 = new(3, "Alexandre Dumas");
            Autor a4 = new(4, "William Shakespeare");
            
            Livro l1 = new(1, "Orgulho e Preconceito", a1);
            Livro l2 = new(2, "O Pequeno Príncipe", a2);
            Livro l3 = new(3, "O Conde de Monte Cristo", a3);
            Livro l4 = new(4, "Romeu e Julieta", a4);
            Livro l5 = new(5, "Amor e Amizade", a1);
            Livro l6 = new(6, "Hamlet", a4);

            _context.Livros.AddRange(l1, l2, l3, l4, l5, l6);

            _context.Autores.AddRange(a1, a2, a3, a4);

            _context.SaveChanges();
        }
    }
}


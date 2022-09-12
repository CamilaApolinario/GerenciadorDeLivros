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
            if (_context.Livros.Any() ||
                _context.Autores.Any())
            {
                return;
            }


            Autor a1 = new("Jane Austen");
            Autor a2 = new("Antoine de Saint-Exupéry");
            Autor a3 = new("Alexandre Dumas");
            Autor a4 = new("William Shakespeare");

            var listAutor = new List<Autor>();
            listAutor.Add(a1);
            listAutor.Add(a2);  
            listAutor.Add(a3);
            listAutor.Add(a4);


            var listLivro = new List<Livro>();

            listLivro.Add(new("Orgulho e Preconceito", a1));
            listLivro.Add(new("O Pequeno Príncipe", a2));
            listLivro.Add(new("O Conde de Monte Cristo", a3));
            listLivro.Add(new("Romeu e Julieta", a4));
            listLivro.Add(new("Amor e Amizade", a1));
            listLivro.Add(new("Hamlet", a4));


            _context.Livros.AddRange(listLivro);

            _context.Autores.AddRange(listAutor);

            _context.SaveChanges();
        }
    }
}


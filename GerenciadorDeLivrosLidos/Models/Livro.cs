using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivrosLidos.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public bool Lido { get; set; }

        public Livro()
        {
        }
        public Livro(string titulo, Autor autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }
}

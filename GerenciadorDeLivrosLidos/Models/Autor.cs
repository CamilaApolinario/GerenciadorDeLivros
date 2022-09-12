using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivrosLidos.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }

        public Autor(string nome)
        {
            Nome = nome;
        }
    }
}
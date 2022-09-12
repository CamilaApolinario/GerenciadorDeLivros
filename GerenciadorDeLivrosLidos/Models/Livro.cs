namespace GerenciadorDeLivrosLidos.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public Livro()
        {
        }
        public Livro(int id, string titulo, Autor autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
        }
    }
}

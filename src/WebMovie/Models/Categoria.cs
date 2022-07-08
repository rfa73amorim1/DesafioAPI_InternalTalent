namespace MvcMovie.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; } 
        public string? Genero { get; set; } = string.Empty;

        //public IEnumerable<Movie> Movies { get; set; }
    }
}
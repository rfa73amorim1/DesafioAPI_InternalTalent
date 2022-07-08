using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }
     
    }
}

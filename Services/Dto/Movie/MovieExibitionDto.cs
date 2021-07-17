using System;

namespace Services.Dto.Movie
{
    public class MovieExibitionDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Genero { get; set; }
        public int GenreId { get; set; }
        public string Disponivel { get; set; }
    }
}
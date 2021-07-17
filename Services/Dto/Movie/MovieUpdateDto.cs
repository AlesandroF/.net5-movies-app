using System;

namespace Services.Dto.Movie
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Ativo { get; set; }
        public int GenreId { get; set; }
    }
}
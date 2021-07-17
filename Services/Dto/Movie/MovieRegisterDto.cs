using System;

namespace Services.Dto.Movie
{
    public class MovieRegisterDto
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int GenreId { get; set; }
        public int Ativo { get; set; } = 1;
    }
}
using System;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Movie : Entity
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Ativo { get; set; }
        
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
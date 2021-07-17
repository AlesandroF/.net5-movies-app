using System;
using System.Collections.Generic;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Genre : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int Ativo { get; private set; }

        public virtual ICollection<Movie> Movie { get; set; }
        
        public Genre(int id, int ativo, DateTime dataCriacao, string nome)
        {
            Id = id;
            Nome = nome;
            DataCriacao = dataCriacao;
            Ativo = ativo;
        }
    }
}
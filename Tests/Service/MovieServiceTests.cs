using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Infra.Interface;
using Moq;
using Services.Dto.Movie;
using Services.Interfaces;
using Services.Services;
using Xunit;

namespace Tests.Service
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _movieRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IMovieService _movieService;

        public MovieServiceTests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            
            _movieRepository = new Mock<IMovieRepository>();
            _mapper = new Mock<IMapper>();

            _movieService = new MovieService(_movieRepository.Object, unitOfWork.Object, _mapper.Object);
        }

        [Fact]
        public void DeleteAsync_DeleteHaveBeenCalled()
        {
            const int Id = 1;
            _movieService.DeleteAsync(Id).Wait();

            _movieRepository.Verify(g => g.DeleteAsync(Id), Times.Once(),
                "Método \"IMovieRepository.DeleteAsync\" não foi invocado");
        }

        [Fact]
        public void GetAllAsync_Repository_WasCalled()
        {
            _movieService.GetAllAsync(default(DateTime), null).Wait();

            _movieRepository.Verify(g => g.GetAllAsync(default(DateTime), null), Times.Once,
                "O método \"IMovieRepository.GetAllAsync\" não foi chamado");
        }

        [Fact]
        public void GetAllAsync_Result()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Ativo = 1,
                    DataCriacao = new DateTime(2020, 12, 01),
                    Nome = "teste"
                }
            };

            _movieRepository.Setup(p => p.GetAllAsync(new DateTime(2020, 12, 01), null))
                .ReturnsAsync(movies);

            _mapper.Setup(e => e.Map<IEnumerable<MovieExibitionDto>>(movies))
                .Returns(new List<MovieExibitionDto>
                {
                    new MovieExibitionDto
                    {
                        Disponivel = "SIM",
                        DataCriacao = new DateTime(2020, 12, 01),
                        Nome = "teste"
                    }
                });

            var result = _movieService.GetAllAsync(new DateTime(2020, 12, 01), null).Result;

            result.Should().SatisfyRespectively(
                first =>
                {
                    first.Disponivel.Should().Be("SIM");
                    first.DataCriacao.Date.Should().Be(new DateTime(2020, 12, 01).Date);
                    first.Nome.Should().Be("teste");
                });
        }

        [Fact]
        public void CreateAsync_VerifyRepositoryWasCalled()
        {
            var movie = new MovieRegisterDto
            {
                Ativo = 1,
                Nome = "teste",
                DataCriacao = new DateTime(2020, 12, 01)
            };

            _mapper.Setup(e => e.Map<Movie>(movie))
                .Returns(new Movie
                {
                    Ativo = 1,
                    DataCriacao = new DateTime(2020, 12, 01),
                    Nome = "teste"
                });

            _movieService.CreateAsync(movie).Wait();

            _movieRepository.Verify(g => g.CreateAsync(It.Is<Movie>(m =>
                m.Ativo == movie.Ativo
                && m.DataCriacao.Date == movie.DataCriacao.Date
                && m.Nome == movie.Nome
               )), Times.Once(), "Método \"IMovieRepository.CreateAsync\" não foi invocado");
        }

        [Fact]
        public void UpdateAsync_Movie_WasChange()
        {
            var movie = new MovieUpdateDto
            {
                Id = 1,
                Ativo = 1,
                Nome = "teste",
                DataCriacao = new DateTime(2020, 12, 01)
            };

            _mapper.Setup(e => e.Map<Movie>(movie))
                .Returns(new Movie
                {
                    Ativo = 1,
                    DataCriacao = new DateTime(2020, 12, 01),
                    Nome = "teste"
                });

            _movieService.UpdateAsync(movie).Wait();

            _movieRepository.Verify(g => g.UpdateAsync(
                It.Is<Movie>(m =>
                           m.Ativo == movie.Ativo
                        && m.DataCriacao.Date == movie.DataCriacao.Date
                        && m.Nome == movie.Nome),
                It.Is<int>(id => id == movie.Id)), Times.Once(),
                "Método \"IMovieRepository.UpdateAsync\" não foi invocado");
        }
    }
}
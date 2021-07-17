using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Infra.Interface;
using Moq;
using Services.Dto.Genre;
using Services.Interfaces;
using Services.Services;
using Xunit;

namespace Tests.Service
{
    public class GenreServiceTests
    {
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IGenreService _genreService;

        public GenreServiceTests()
        {
            _genreRepository = new Mock<IGenreRepository>();
            _mapper = new Mock<IMapper>();

            _genreService = new GenreService(_genreRepository.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllAsync_Repository_WasCalled()
        {
            _genreService.GetAllAsync().Wait();

            _genreRepository.Verify(g => g.GetAllAsync(), Times.Once,
                "O método \"IGenreRepository.GetAllAsync\" não foi chamado");
        }

        [Fact]
        public void GetAllAsync_Result()
        {
            IEnumerable<Genre> genres = new List<Genre>
            {
                new(1, 1, DateTime.Now, "teste")
            };

            _genreRepository.Setup(p => p.GetAllAsync())
                .ReturnsAsync(genres);

            _mapper.Setup(e => e.Map<IEnumerable<GenreExibitionDto>>(genres))
                .Returns(new List<GenreExibitionDto>
                {
                    new GenreExibitionDto
                    {
                        Id = 1,
                        Nome = "teste"
                    }
                });
            
            var result = _genreService.GetAllAsync().Result;

            result.Should().SatisfyRespectively(
                first =>
                {
                    first.Id.Should().Be(1);
                    first.Nome.Should().Be("teste");
                });
        }
    }
}
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Dto.Genre;
using Services.Interfaces;
using Tests.Helper;
using WebApi.Controllers;
using Xunit;

namespace Tests.Api
{
    public class GenreControllerTest
    {
        private readonly Mock<IGenreService> _genreService;
        private readonly GenresController _controller;
        
        public GenreControllerTest()
        {
            _genreService = new Mock<IGenreService>();
            _controller = new GenresController(_genreService.Object);
        }

        [Fact]
        public void GetAllGenresAsync_ReturnsExpectedStatusCode()
        {
            var actionResult = _controller.GetAllAsync().Result;
        
            actionResult.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        
        [Fact]
        public void GetAllGenresAsync_ValidRoute_ReturnsExpectedRoute()
        {
            const string expectedRoute = "[controller]/";
        
            var route = ControllerHelper.GetRoute<GenresController>(nameof(GenresController.GetAllAsync));
        
            route.Should().Be(expectedRoute);
        }
        
        [Fact]
        public void GetAllGenresAsync_VerifyServiceWasCalled()
        {
            _genreService.Setup(e => e.GetAllAsync())
                .ReturnsAsync(new List<GenreExibitionDto>());
        
            _ = _controller.GetAllAsync().Result;
        
            _genreService.Verify(r => r.GetAllAsync(), Times.Once,
                "Método \"IGenreService.GetAllAsync\" não foi invocado");
        }
        
        [Fact]
        public void GetAllGenresAsync_ReturnsExpectedType()
        {
            _genreService.Setup(e => e.GetAllAsync())
                .ReturnsAsync(new List<GenreExibitionDto>());
        
            var actionResult = _controller.GetAllAsync().Result;
        
            actionResult.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<List<GenreExibitionDto>>();
        }
    }
}
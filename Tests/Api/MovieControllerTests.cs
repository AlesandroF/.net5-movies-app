using System.Collections.Generic;
using System.Net;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Dto.Movie;
using Services.Interfaces;
using Tests.Helper;
using WebApi.Controllers;
using Xunit;

namespace Tests.Api
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _movieService;
        private readonly MoviesController _controller;

        public MovieControllerTests()
        {
            _movieService = new Mock<IMovieService>();
            _controller = new MoviesController(_movieService.Object);
        }

        [Fact]
        public void GetAllAsync_ReturnsExpectedStatusCode()
        {
            var actionResult = _controller.GetAllAsync(null, null).Result;

            actionResult.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void GetAllAsync_ValidRoute_ReturnsExpectedRoute()
        {
            const string expectedRoute = "[controller]/";

            var route = ControllerHelper.GetRoute<MoviesController>(nameof(MoviesController.GetAllAsync));

            route.Should().Be(expectedRoute);
        }

        [Fact]
        public void GetAllAsync_VerifyServiceWasCalled()
        {
            _movieService.Setup(e => e.GetAllAsync(null, null))
                .ReturnsAsync(new List<MovieExibitionDto>());

            _ = _controller.GetAllAsync(null, null).Result;

            _movieService.Verify(r => r.GetAllAsync(null, null), Times.Once,
                "Método \"IMovieService.GetAllAsync\" não foi invocado");
        }

        [Fact]
        public void GetAllAsync_ReturnsExpectedType()
        {
            _movieService.Setup(e => e.GetAllAsync(null, null))
                .ReturnsAsync(new List<MovieExibitionDto>());

            var actionResult = _controller.GetAllAsync(null, null).Result;

            actionResult.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<List<MovieExibitionDto>>();
        }

        

        [Fact]
        public void RegisterAsync_ReturnsExpectedStatusCode()
        {
            var dto = new MovieRegisterDto();

            var actionResult = _controller.RegisterAsync(dto).Result;

            actionResult.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        [Fact]
        public void RegisterAsync_ValidRoute_ReturnsExpectedRoute()
        {
            const string expectedRoute = "[controller]/";

            var route = ControllerHelper.GetRoute<MoviesController>(nameof(MoviesController.RegisterAsync));

            route.Should().Be(expectedRoute);
        }

        [Fact]
        public void RegisterAsync_VerifyServiceWasCalled()
        {
            var dto = new MovieRegisterDto();

            _ = _controller.RegisterAsync(dto).Result;

            _movieService.Verify(r => r.CreateAsync(dto), Times.Once,
                "Método \"IMovieService.CreateAsync\" não foi invocado");
        }

        [Fact]
        public void UpdateAsync_ReturnsExpectedStatusCode()
        {
            var dto = new MovieUpdateDto
            {
                Id = 1
            };

            var actionResult = _controller.UpdateAsync(dto).Result;

            actionResult.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        [Fact]
        public void UpdateAsync_ValidRoute_ReturnsExpectedRoute()
        {
            const string expectedRoute = "[controller]/";

            var route = ControllerHelper.GetRoute<MoviesController>(nameof(MoviesController.UpdateAsync));

            route.Should().Be(expectedRoute);
        }

        [Fact]
        public void UpdateAsync_VerifyServiceWasCalled()
        {
            var dto = new MovieUpdateDto
            {
                Id = 1
            };

            _ = _controller.UpdateAsync(dto).Result;

            _movieService.Verify(r => r.UpdateAsync(dto), Times.Once,
                "Método \"IMovieService.UpdateAsync\" não foi invocado");
        }

        [Fact]
        public void DeleteAsync_ReturnsExpectedStatusCode()
        {
            const int id = 1;

            var actionResult = _controller.DeleteAsync(id).Result;

            actionResult.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        [Fact]
        public void DeleteAsync_ValidRoute_ReturnsExpectedRoute()
        {
            const string expectedRoute = "[controller]/";

            var route = ControllerHelper.GetRoute<MoviesController>(nameof(MoviesController.DeleteAsync));

            route.Should().Be(expectedRoute);
        }

        [Fact]
        public void DeleteAsync_VerifyServiceWasCalled()
        {
            const int id = 1;

            _ = _controller.DeleteAsync(id).Result;

            _movieService.Verify(r => r.DeleteAsync(id), Times.Once,
                "Método \"IMovieService.DeleteAsync\" não foi invocado");
        }
    }
}
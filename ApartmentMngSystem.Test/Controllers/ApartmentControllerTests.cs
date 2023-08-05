using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Controllers;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Web.Mvc;
using Xunit;

namespace ApartmentMngSystem.Test.Controllers
{
    public class ApartmentControllerTests
    {
        private Mock<IApartmentService> _mockApartmentService;
        private Mock<IUserService> _mockUserService;
        private ApartmentController _controller;

        public ApartmentControllerTests()
        {
            _mockApartmentService = new Mock<IApartmentService>();
            _mockUserService = new Mock<IUserService>();
            _controller = new ApartmentController(_mockApartmentService.Object, _mockUserService.Object);
        }

        [Fact]
        public async Task Index_ReturnsOkResult_WithListOfApartments()
        {
            // Arrange
            _mockApartmentService.Setup(service => service.GetAll())
                .ReturnsAsync(GetTestApartments());

            // Act
            var result = await _controller.Index();

            // Assert
            var okResult = ActionResult.Result as OkObjectResult;
            var apartments = okResult.Value as List<Apartment>;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(2, apartments.Count);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_ForInvalidModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await _controller.Create(new Apartment());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        // Yardımcı metod
        private List<Apartment> GetTestApartments()
        {
            return new List<Apartment>
            {
                new Apartment { Id = 1, /* diğer özellikler */ },
                new Apartment { Id = 2, /* diğer özellikler */ }
            };
        }
    }
}

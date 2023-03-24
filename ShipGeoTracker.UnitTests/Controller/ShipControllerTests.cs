using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using ShipGeoTracker.Api.Controllers;
using ShipGeoTracker.Api.Infrastructure.Models;
using ShipGeoTracker.Api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShipGeoTracker.UnitTests.Controller
{
    [TestClass]
    public class ShipControllerTests
    {
        [TestMethod]
        public async Task Add_ReturnBadResultResponse()
        {
            // Arrange
            var automocker = new AutoMocker();

            var controller = automocker.CreateInstance<ShipController>();

            // Act
            var result = await controller.Add(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task Add_ReturnValidResponse()
        {
            // Arrange
            var automocker = new AutoMocker();

            var controller = automocker.CreateInstance<ShipController>();

            var requestModel = new ShipRequestModel()
            {
                Latitude = 50.5,
                Longitude = 65.5,
                Name = "Test Ship",
                Velocity = 25
            };

            var responseModel = new ShipResponseModel()
            {
                Id= Guid.NewGuid(),
                Latitude = 50.5,
                Longitude = 65.5,
                Name = "Test Ship",
                Velocity = 25
            };

            automocker.Setup<IShipService, Task<ShipResponseModel>>
               (x => x.AddAsync(requestModel)).ReturnsAsync(responseModel);

            // Act
            var result = await controller.Add(requestModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okObjectResult = result as OkObjectResult;
        }
    }
}

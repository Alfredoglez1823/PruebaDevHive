using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PruebaDevHive.Controllers;
using PruebaDevHive.Models;
using PruebaDevHive.Repository;
using PruebaDevHive.Services;
using Xunit;

namespace TestPruebaDevHive
{
    public class InmueblesControllerTests
    {
        private readonly Mock<IGenericRepository<Inmueble, InmueblesDevHiveContext>> _mockRepository;
        private readonly InmueblesController _controller;

        public InmueblesControllerTests()
        {
            _mockRepository = new Mock<IGenericRepository<Inmueble, InmueblesDevHiveContext>>();
            var service = new GenericService<Inmueble, InmueblesDevHiveContext>(_mockRepository.Object);
            _controller = new InmueblesController(service, _mockRepository.Object);
        }

        [Fact]
        public async Task GetInmueblesFromStoredProcedure_ReturnsOkResult_WithListOfInmuebles()
        {
            // Arrange
            var inmueblesList = new List<Inmueble> { new Inmueble { Id = 1, Nombre = "Inmueble 1" } };
            _mockRepository.Setup(repo => repo.GetAllFromStoredProcedureAsync("GetAllInmuebles"))
                        .ReturnsAsync(inmueblesList);

            // Act
            var result = await _controller.GetInmueblesFromStoredProcedure();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Inmueble>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetInmueblesFromStoredProcedure_ReturnsNotFound_WhenNoInmuebles()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllFromStoredProcedureAsync("GetAllInmuebles"))
                        .ReturnsAsync((IEnumerable<Inmueble>)null);

            // Act
            var result = await _controller.GetInmueblesFromStoredProcedure();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProductos_ReturnsOkResult_WithListOfProductos()
        {
            // Arrange
            var productosList = new List<Inmueble> { new Inmueble { Id = 1, Nombre = "Producto 1" } };
            _mockRepository.Setup(repo => repo.GetAllAsync())
                        .ReturnsAsync(productosList);

            // Act
            var result = await _controller.GetProductos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Inmueble>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetProductos_ReturnsNotFound_WhenNoProductos()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllAsync())
                        .ReturnsAsync((IEnumerable<Inmueble>)null);

            // Act
            var result = await _controller.GetProductos();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProducto_ReturnsOkResult_WithProducto()
        {
            // Arrange
            var producto = new Inmueble { Id = 1, Nombre = "Producto 1" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1))
                        .ReturnsAsync(producto);

            // Act
            var result = await _controller.GetProducto(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Inmueble>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetProducto_ReturnsNotFound_WhenProductoNotExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1))
                        .ReturnsAsync((Inmueble)null);

            // Act
            var result = await _controller.GetProducto(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostProducto_ReturnsCreatedAtActionResult_WithCreatedProducto()
        {
            // Arrange
            var producto = new Inmueble { Id = 1, Nombre = "Producto 1" };
            _mockRepository.Setup(repo => repo.CreateAsync(producto))
                        .ReturnsAsync(producto);

            // Act
            var result = await _controller.PostProducto(producto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Inmueble>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task PutProducto_ReturnsOkResult_WhenProductoUpdated()
        {
            // Arrange
            var producto = new Inmueble { Id = 1, Nombre = "Producto 1" };
            _mockRepository.Setup(repo => repo.UpdateAsync(1, producto))
                        .ReturnsAsync(true);

            // Act
            var result = await _controller.PutProducto(1, producto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task PutProducto_ReturnsNotFound_WhenProductoNotUpdated()
        {
            // Arrange
            var producto = new Inmueble { Id = 1, Nombre = "Producto 1" };
            _mockRepository.Setup(repo => repo.UpdateAsync(1, producto))
                        .ReturnsAsync(false);

            // Act
            var result = await _controller.PutProducto(1, producto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteProducto_ReturnsNoContent_WhenProductoDeleted()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteAsync(1))
                        .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProducto(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteProducto_ReturnsNotFound_WhenProductoNotDeleted()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteAsync(1))
                        .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProducto(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

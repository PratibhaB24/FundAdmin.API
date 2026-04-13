using FundAdmin.API.DTOs.Fund;
using FundAdmin.API.Exceptions;
using FundAdmin.API.Models;
using FundAdmin.API.Repositories;
using FundAdmin.API.Services;
using Moq;

namespace FundAdmin.API.Tests.Services
{
    public class FundServiceTests
    {
        private readonly Mock<IGenericRepository<Fund>> _mockRepo;
        private readonly FundService _service;

        public FundServiceTests()
        {
            _mockRepo = new Mock<IGenericRepository<Fund>>();
            _service = new FundService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllFunds()
        {
            // Arrange
            var funds = new List<Fund>
        {
            new Fund { FundId = Guid.NewGuid(), Name = "Fund1", Currency = "USD" },
            new Fund { FundId = Guid.NewGuid(), Name = "Fund2", Currency = "EUR" }
        };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(funds);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsFund_WhenExists()
        {
            var fundId = Guid.NewGuid();

            var fund = new Fund
            {
                FundId = fundId,
                Name = "Test Fund",
                Currency = "USD"
            };

            _mockRepo.Setup(r => r.GetByIdAsync(fundId)).ReturnsAsync(fund);

            var result = await _service.GetByIdAsync(fundId);

            Assert.NotNull(result);
            Assert.Equal("Test Fund", result.Name);
        }

        [Fact]
        public async Task CreateAsync_AddsFund()
        {
            var dto = new CreateFundDto
            {
                Name = "New Fund",
                Currency = "USD",
                LaunchDate = DateTime.UtcNow
            };

            await _service.CreateAsync(dto);

            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Fund>()), Times.Once);
            _mockRepo.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesFund_WhenExists()
        {
            var fundId = Guid.NewGuid();

            var fund = new Fund { FundId = fundId };

            _mockRepo.Setup(r => r.GetByIdAsync(fundId)).ReturnsAsync(fund);

            var dto = new UpdateFundDto
            {
                Name = "Updated",
                Currency = "INR"
            };

            await _service.UpdateAsync(fundId, dto);

            _mockRepo.Verify(r => r.Update(It.IsAny<Fund>()), Times.Once);
            _mockRepo.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_DeletesFund_WhenExists()
        {
            var fundId = Guid.NewGuid();

            var fund = new Fund { FundId = fundId };

            _mockRepo.Setup(r => r.GetByIdAsync(fundId)).ReturnsAsync(fund);

            await _service.DeleteAsync(fundId);

            _mockRepo.Verify(r => r.Delete(It.IsAny<Fund>()), Times.Once);
            _mockRepo.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowNotFoundException_WhenFundDoesNotExist()
        {
            var fundId = Guid.NewGuid();

              _mockRepo.Setup(r => r.GetByIdAsync(fundId))
                .ReturnsAsync((Fund)null);

            var exception = await Assert.ThrowsAsync<NotFoundException>(
                () => _service.GetByIdAsync(fundId));

            Assert.Equal("Fund not found", exception.Message);
        }
    }
}

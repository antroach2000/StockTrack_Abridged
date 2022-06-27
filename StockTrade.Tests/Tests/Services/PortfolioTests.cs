using NSubstitute;
using NUnit.Framework;
using StockTrade.API.Repositories.Interfaces;
using StockTrade.API.Services;
using StockTrade.API.Services.Interfaces;
using StockTrade.Tests.TestData;

namespace StockTrade.Tests.Tests.Services
{
    [TestFixture]
    public class PortfolioTests
    {
        private IPortfolioRepository? _portfolioRepository;
        private IIndustryGroupService? _industryGroupService;
        private IPortfolioService? _portfolioService;
        [SetUp]
        public void Setup()
        {
            _portfolioRepository = Substitute.For<IPortfolioRepository>();
            _industryGroupService = Substitute.For<IIndustryGroupService>();
            _portfolioService = Substitute.For<IPortfolioService>();
        }
        [Test]
        public void PortfolioService_AddAsync_Null_PortfolioModel_ThrowsArgumentException()
        {
            // Arrange
            var portfolioService = new PortfolioService(_portfolioRepository, _industryGroupService);
            // Act         
            // Assert
            Assert.That(() => portfolioService.AddAsync(NewPortfolioTestData.NullPortfolioModel), Throws.ArgumentException);
        }
        [Test]
        public void PortfolioService_AddAsync_Invalid_IndustryGroupId_ThrowsArgumentException()
        {
            // Arrange
            var portfolioService = new PortfolioService(_portfolioRepository, _industryGroupService);
            // Act         
            // Assert
            Assert.That(() => portfolioService.AddAsync(NewPortfolioTestData.InvalidIndustryGroupId), Throws.ArgumentException);
        }
        [Test]
        public void PortfolioService_AddAsync_Zero_IndustryGroupId_ThrowsArgumentException()
        {
            // Arrange
            var portfolioService = new PortfolioService(_portfolioRepository, _industryGroupService);

            // Act         
            // Assert
            Assert.That(() => portfolioService.AddAsync(NewPortfolioTestData.InvalidIndustryGroupIdZero), Throws.ArgumentException);
        }
        [Test]
        public void PortfolioService_RemoveAsync_Empty_GUID_ThrowsArgumentException()
        {
            // Arrange
            var portfolioService = new PortfolioService(_portfolioRepository, _industryGroupService);
            var id = Guid.Empty;

            // Act         
            // Assert
            Assert.That(() => portfolioService.RemoveAsync(id), Throws.ArgumentException);
        }
        [Test]
        public void PortfolioService_GetAsync_Empty_GUID_ThrowsArgumentException()
        {
            // Arrange
            var portfolioService = new PortfolioService(_portfolioRepository, _industryGroupService);
            var id = Guid.Empty;

            // Act         
            // Assert
            Assert.That(() => portfolioService.GetAsync(id), Throws.ArgumentException);
        }
    }
}

using Moq;
using Practice.Core.Services;
using Practice.DataAccess.Interfaces;

namespace Practice.Api.Tests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;
        public CalculatorServiceTests()
        {
            //Arrange
            Mock<ICalculatorRepository> moq = new Mock<ICalculatorRepository>();
            moq.Setup(t => t.InsertLogInDb(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<int>()
                )).Verifiable();
            _calculatorService = new CalculatorService(moq.Object);
        }

        [Theory]
        [InlineData(1, 2, "+", 3)]
        [InlineData(-4, -6, "+", -10)]
        [InlineData(-2, 2, "-", -4)]
        public void HappyPath(int a, int b, string operation, int? expected)
        {
            int? result = null;
            result = _calculatorService.Calculate(a, b, operation);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(-2, 2, "n")]
        [InlineData(-2, 2, "a")]
        [InlineData(-2, 2, "")]
        public void UnhappyPath(int a, int b, string operation)
        {
            Assert.ThrowsAny<InvalidOperationException>(
                () => _calculatorService.Calculate(a, b, operation));
        }
    }
}

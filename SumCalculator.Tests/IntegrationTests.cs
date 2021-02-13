using Microsoft.Extensions.Logging;
using Moq;
using SumCalculator.Application;
using SumCalculator.Application.Interfaces;
using SumCalculator.Application.SumAlgorighms;
using SumCalculator.Infrastructure.FilesReader;
using Xunit;

namespace SumCalculator.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void SumCalculatorWithSuccessfulResult()
        {
            //Arrange
            string[] data = new string[] { "1", "2", "3", "B", "5", "6", "7", "8", "A", "10" };

            var loggerMock = new Mock<ILogger<ArraysConverter>>();
            ILogger<ArraysConverter> logger = loggerMock.Object;

            IIntSumCalculator summator = new BasicIntSumCalculator();
            Mock<INumbersDataReader> mockReader = new Mock<INumbersDataReader>();
                     
            ArraysConverter converter = new ArraysConverter(logger);
            mockReader.Setup(reader => reader.Read(It.IsAny<string>())).Returns(converter.ConvertWithFiltering(data));

            var app = new SumCalculatorApp(summator, mockReader.Object, new Mock<ILogger<SumCalculatorApp>>().Object);

            //Act
            long result = app.Run(It.IsAny<string>());

            //Assert
            Assert.Equal(42, result);
        }
    }
}

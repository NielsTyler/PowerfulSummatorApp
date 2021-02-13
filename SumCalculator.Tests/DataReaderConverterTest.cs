using Microsoft.Extensions.Logging;
using Moq;
using SumCalculator.Application.Exceptions;
using SumCalculator.Application.Interfaces;
using SumCalculator.Infrastructure.FilesReader;
using System;
using Xunit;

namespace SumCalculator.Tests
{
    public class DataReaderConverterTest
    {

        [Theory]                
        [InlineData("10", "test", "3", "B")]
        public void NumbersConverterTest(params string[] data)
        {            
            var loggerMock = new Mock<ILogger<ArraysConverter>>();
            ILogger<ArraysConverter> logger = loggerMock.Object;

            ArraysConverter converter = new ArraysConverter(logger);            
            var result = converter.ConvertWithFiltering(data);

            Assert.Equal(new long[] { 10, 3 }, result);
        }

        [Fact]
        public void ReaderWrongDataTest()
        {
            var loggerMock = new Mock<ILogger<ArraysConverter>>();
            ILogger<ArraysConverter> logger = loggerMock.Object;

            var arraysConverter = new ArraysConverter(logger);
            INumbersDataReader reader = new CsvFileReader(arraysConverter);            

            String wrongPath = String.Empty;

            Assert.Throws<SumCalcAppException>(() => reader.Read(String.Empty));
        }
    }
}

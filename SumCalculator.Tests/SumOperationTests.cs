using SumCalculator.Application.Interfaces;
using SumCalculator.Application.SumAlgorighms;
using System;
using System.Linq;
using Xunit;

namespace SumCalculator.Tests
{
    public class SumOperationTests
    {        
        [Theory]
        [InlineData(new int[] { 10, 3, -2 })]
        public void BasicSumOperationTest(int[] array)
        {
            IIntSumCalculator summator = new BasicIntSumCalculator();

            int result = summator.Sum(array);
            Assert.Equal(11, result);
        }

        [Theory]
        [InlineData(new int[] { 10, 3, -2 })]
        public void EvenSumOperationTest(int[] array)
        {
            IIntSumCalculator summator = new EvenNumbersSumCalculator();

            int result = summator.Sum(array);
            Assert.Equal(8, result);
        }
    }
}

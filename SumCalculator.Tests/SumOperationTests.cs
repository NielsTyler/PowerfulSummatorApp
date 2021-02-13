using SumCalculator.Application.Exceptions;
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
        [InlineData(new long[] { 10, 3, -2 })]
        public void BasicSumOperationTest(long[] array)
        {
            IIntSumCalculator summator = new BasicIntSumCalculator();

            long result = summator.Sum(array);
            Assert.Equal(11, result);
        }

        [Theory]
        [InlineData(new long[] { 10, 3, -2 })]
        public void EvenSumOperationTest(long[] array)
        {
            IIntSumCalculator summator = new FilteredNumbersSumCalculator();

            long result = summator.Sum(array);
            Assert.Equal(8, result);
        }

        [Theory]
        //[InlineData(new int[] { 256741038, 623958417, 467905213, 714532089, 938071625 })]
        [InlineData(new long[] { long.MaxValue, 3, -2 })]              
        public void OverflowErrorOnSumOperation(long[] array)
        {
            IIntSumCalculator summator = new BasicIntSumCalculator();

            Assert.Throws<SumCalcAppException>(() => summator.Sum(array));
        }
    }
}

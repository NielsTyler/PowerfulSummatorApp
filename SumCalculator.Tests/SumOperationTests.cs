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
            //ISumOperation summator = new SumOperationBasic();
                      
            int result = array.Sum();//summator.Sum(array);
            Assert.Equal(11, result);
        }
    }
}

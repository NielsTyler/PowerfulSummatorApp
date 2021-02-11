using SumCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumCalculator.Application.SumAlgorighms
{
    public class BasicIntSumCalculator : IIntSumCalculator
    {        
        public int Sum(int[] array)
        {
            return array.Sum();
        }
    }
}

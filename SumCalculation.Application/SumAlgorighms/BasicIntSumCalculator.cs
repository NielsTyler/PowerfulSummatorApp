using SumCalculator.Application.Exceptions;
using SumCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SumCalculator.Application.SumAlgorighms
{
    public class BasicIntSumCalculator : IIntSumCalculator
    {        
        public long Sum(IEnumerable<long> array)
        {
            if (array == null)
            {
                throw new SumCalcAppException("Data can not be empty.");  
            }

            try
            {
                checked
                {
                    return array.Sum();
                }
            }
            catch (OverflowException ex)
            {
                throw new SumCalcAppException("Too big numbers. Consider to remove us of them.", ex);
            }
        }
    }
}

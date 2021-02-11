using System;
using System.Collections.Generic;
using System.Text;

namespace SumCalculator.Application.Exceptions
{    
    public class SumCalcAppException : Exception
    {
        public SumCalcAppException()
        {
        }

        public SumCalcAppException(string message)
            : base(message)
        {
        }

        public SumCalcAppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}

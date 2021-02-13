using System.Collections.Generic;

namespace SumCalculator.Application.Interfaces
{
    public interface IIntSumCalculator
    {
        long Sum(IEnumerable<long> array);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCalculator.Application.Interfaces
{
    public interface INumbersDataReader
    {
        IEnumerable<long> Read(string path);
    }
}

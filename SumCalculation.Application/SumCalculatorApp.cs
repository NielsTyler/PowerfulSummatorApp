using Microsoft.Extensions.Logging;
using SumCalculator.Application.Exceptions;
using SumCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCalculator.Application
{
    public class SumCalculatorApp
    {
        private readonly INumbersDataReader _reader;
        private readonly ILogger<SumCalculatorApp> _logger;
        private IIntSumCalculator _summator;
        public SumCalculatorApp(IIntSumCalculator summator, INumbersDataReader reader, ILogger<SumCalculatorApp> logger)
        {
            _reader = reader;
            _logger = logger;
            _summator = summator;
        }

        public int Run(string path)
        {
            _logger.LogInformation("Starting application");

            try
            {
                int[] data = _reader.Read(path);

                return _summator.Sum(data);
            }
            catch (SumCalcAppException ex)
            {
                _logger.LogError("Error occured.", ex);

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Unhandled internal error.", ex);

                throw new SumCalcAppException("Internal error.", ex);
            }
        }
    }
}

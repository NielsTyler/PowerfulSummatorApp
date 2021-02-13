using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumCalculator.Infrastructure.FilesReader
{
    public class ArraysConverter
    {
        readonly ILogger<ArraysConverter> _logger;
        const string ERROR_ITEM_NOT_NUMERIC = "/“{0}/” is not number and was ignored.";

        public ArraysConverter(ILogger<ArraysConverter> logger)
        {
            _logger = logger;
        }

        public IEnumerable<long> ConvertWithFiltering(string[] strArray)
        {          
            foreach (string str in strArray)
            {                
                if (long.TryParse(str, out var res))
                {
                    yield return res;
                }
                else
                {
                    _logger.LogInformation(String.Format(ERROR_ITEM_NOT_NUMERIC, str));
                }
            }
        }                          
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumCalculator.Infrastructure.FilesReader
{
    public class ArraysConverter
    {
        private readonly ILogger<ArraysConverter> _logger;
        private const string ERROR_ITEM_NOT_NUMERIC = "/“{0}/” is not number and was ignored.";

        public ArraysConverter(ILogger<ArraysConverter> logger)
        {
            _logger = logger;
        }

        public int[] ConvertWithFiltering(string[] strArray)
        {
            List<int> numbers = new List<int>();            

            foreach (string str in strArray)
            {
                int res;
                if (int.TryParse(str, out res))
                {
                    numbers.Add(res);
                }
                else
                {
                    _logger.LogInformation(String.Format(ERROR_ITEM_NOT_NUMERIC, str));
                }
            }

            return numbers.ToArray();
        }                          
    }
}

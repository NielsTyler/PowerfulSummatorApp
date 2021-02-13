using SumCalculator.Application.Exceptions;
using SumCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SumCalculator.Infrastructure.FilesReader
{
    public class CsvFileReader: INumbersDataReader
    {
        readonly ArraysConverter _converter;

        public CsvFileReader(ArraysConverter converter)
        {
            _converter = converter;
        }               

        string[] ReadLine(string path)
        {
            if (String.IsNullOrEmpty(path) || !File.Exists(path))
            {
                throw new SumCalcAppException("Wrong path \"{path}\" or such file does not exist.");
            }

            using (var reader = new StreamReader(path))
            {                               
                 var line = reader.ReadLine();

                return line.Split(',');
            }
        }

        public IEnumerable<long> Read(string path)
        {
            string[] array = ReadLine(path);

            return _converter.ConvertWithFiltering(array);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SumCalculator.Application;
using SumCalculator.Application.Exceptions;
using SumCalculator.Application.Interfaces;
using SumCalculator.Infrastructure.FilesReader;
using SumCalculatorConsole;
using System;
using System.IO;

namespace SumCalculatorConsole
{
    class Program
    {
        private const string DATA_FILE_NAME = "Numbers.txt";
        private const string PATH = @"C:\Temp";
        private const string INTRODUCTION = "Console application which can read text file\nand parse comma separated numbers.\nPls press any key to start ..\n";

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                        .ConfigureServices()
                                        .BuildServiceProvider();

            Console.WriteLine(INTRODUCTION);
            Console.ReadKey();

            try
            {
                string pathToFile = Path.Combine(PATH, DATA_FILE_NAME);
                var app = serviceProvider.GetService<SumCalculatorApp>();

                long result = app.Run(pathToFile);

                Console.WriteLine($"Sum of numbers: {result}");
            }
            catch (SumCalcAppException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Sorry, error is occured. Pls, write to technical specialist: test@test.com", ex);
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SumCalculator.Application;
using SumCalculator.Application.Interfaces;
using SumCalculator.Application.SumAlgorighms;
using SumCalculator.Infrastructure.FilesReader;
using System;

namespace SumCalculatorConsole
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IIntSumCalculator, BasicIntSumCalculator>();
            services.AddTransient<INumbersDataReader, CsvFileReader>();
            services.AddTransient<ArraysConverter>();
            services.AddTransient<SumCalculatorApp>();

            services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
            });
            
            return services;
        }
    }
}

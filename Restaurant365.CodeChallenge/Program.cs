using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.Extensions.DependencyInjection;
using Restaurant365.CodeChallenge.Services.Interfaces;
using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServices();

            var app = services.GetRequiredService<CalculatorApp>();

            while (true)
            {
                Console.WriteLine("Provide your calculation");

                var calculation = Console.ReadLine();

                var calculationResult = app.Process(calculation);

                Console.WriteLine($"Result: {calculationResult}");
            }
        }

        private static ServiceProvider CreateServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICalculatorService, CalculatorService>()
                .AddTransient<IInputConversionService, InputConversionService>()
                .AddTransient<ISplitService, SplitService>()
                .AddTransient<IValidationService, ValidationService>()
                .AddSingleton<CalculatorApp>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}

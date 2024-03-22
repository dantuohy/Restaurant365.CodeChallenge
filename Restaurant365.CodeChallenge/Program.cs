using Microsoft.Extensions.DependencyInjection;
using Restaurant365.CodeChallenge.Services.Interfaces;
using Restaurant365.CodeChallenge.Services;
using Restaurant365.CodeChallenge.Models;
using Restaurant365.CodeChallenge.Extensions;

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
                var arguments = new CalculationArguments();

                Console.WriteLine("Provide your calculation");

                arguments.Calculation = Console.ReadLine();

                arguments.CustomDelimiter = RequestCustomDelimiter();
                arguments.AllowNegatives = RequestNegativeNumbers();
                arguments.UpperBound = RequestUpperBound();
                arguments.Operator = RequestOperator();

                try
                {
                    var calculationResult = app.Process(arguments);
                    Console.WriteLine($"Result: {calculationResult.Formula} = {calculationResult.Result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string? RequestCustomDelimiter()
        {
            Console.WriteLine("Custom Delimiter? (Enter to use default)?");
            return Console.ReadLine();
        }

        private static bool RequestNegativeNumbers()
        {
            bool? result = null;

            while (result == null)
            {
                Console.WriteLine("Allow Negative? (Y/N or press enter for default yes)");
                var input = Console.ReadLine();

                if (input == null || input == string.Empty || input.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                }
                else if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = false;
                }
            }

            return result.Value;
        }

        private static int RequestUpperBound()
        {
            int? result = null;

            while (result == null)
            {
                Console.WriteLine("Set upper bound? (any positive number or press enter for default of no upper bound)");

                var input = Console.ReadLine();

                if(input == null || input == string.Empty)
                {
                    return int.MaxValue;
                }

                int upperBound;

                if (int.TryParse(input, out upperBound) && upperBound > 0)
                {
                    result = upperBound;
                }
            }

            return result.Value;
        }

        private static Operator RequestOperator()
        {
            Operator? result = null;

            while (result == null)
            {
                Console.WriteLine("Operator (+ - * / default +)");
                var input = Console.ReadLine();

                result = OperatorExtensions.StringToOperator(input);
            }

            return result.Value;
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

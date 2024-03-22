using Restaurant365.CodeChallenge.Extensions;
using Restaurant365.CodeChallenge.Models;
using Restaurant365.CodeChallenge.Services.Interfaces;

namespace Restaurant365.CodeChallenge.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(List<int> numbers, Operator operation)
        {
            if(numbers == null || !numbers.Any())
            {
                return 0;
            }

            switch (operation)
            {
                case Operator.ADD:
                    return Add(numbers);
                case Operator.SUBTRACT:
                    return Subtract(numbers);
                case Operator.MULTIPLY:
                    return Multiply(numbers);
                case Operator.DIVIDE:
                    return Divide(numbers);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation));
            }
        }

        public string GetFormula(List<int> numbers, Operator operation)
        {
            return string.Join(operation.GetOperator(), numbers);
        }

        private decimal Add(List<int> numbers)
        {
            return numbers.Sum(x => x);
        }

        private decimal Subtract(List<int> numbers)
        {
            var result = numbers[0];
            for(int i = 1; i < numbers.Count; i++)
            {
                result = result - numbers[i];
            }

            return result;
        }

        private decimal Multiply(List<int> numbers)
        {
            var result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = result * numbers[i];
            }

            return result;
        }

        private decimal Divide(List<int> numbers)
        {
            decimal result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = result / numbers[i];
            }

            return result;
        }
    }
}

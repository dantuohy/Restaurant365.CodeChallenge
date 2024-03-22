using Restaurant365.CodeChallenge.Services.Interfaces;

namespace Restaurant365.CodeChallenge.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Calculate(List<int> numbers)
        {
            return numbers == null ? 0 : numbers.Sum(x => x);
        }
    }
}

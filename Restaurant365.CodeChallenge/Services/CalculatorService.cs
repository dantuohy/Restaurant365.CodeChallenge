namespace Restaurant365.CodeChallenge.Services
{
    public class CalculatorService
    {
        public int Calculate(List<int> numbers)
        {
            return numbers == null ? 0 : numbers.Sum(x => x);
        }
    }
}

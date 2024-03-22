namespace Restaurant365.CodeChallenge.Services.Interfaces
{
    public interface ICalculatorService
    {
        int Calculate(List<int> numbers);
        string GetFormula(List<int> numbers);
    }
}

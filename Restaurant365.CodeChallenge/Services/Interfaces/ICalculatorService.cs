using Restaurant365.CodeChallenge.Models;

namespace Restaurant365.CodeChallenge.Services.Interfaces
{
    public interface ICalculatorService
    {
        decimal Calculate(List<int> numbers, Operator operation);
        string GetFormula(List<int> numbers, Operator operation);
    }
}

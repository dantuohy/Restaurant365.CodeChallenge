using Restaurant365.CodeChallenge.Models;

namespace Restaurant365.CodeChallenge.Services.Interfaces
{
    public interface IValidationService
    {
        ValidationResponse ValidateInput(string input);
        ValidationResponse ValidateInputNumbers(List<int> input, bool allowNegativeNumbers);
    }
}

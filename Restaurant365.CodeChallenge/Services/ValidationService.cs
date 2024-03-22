using Restaurant365.CodeChallenge.Models;

namespace Restaurant365.CodeChallenge.Services
{
    public class ValidationService
    {
        public ValidationResponse ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ValidationResponse.Invalid("Please supply an input value");
            }

            return ValidationResponse.Valid();
        }

        public ValidationResponse ValidateInputNumbers(List<int> input)
        {
            if (input.Any(x => x < 0))
            {
                return ValidationResponse.Invalid($"Invalid negative number(s) in  calculation: {string.Join(", ", input.Where(x => x < 0))}");
            }

            return ValidationResponse.Valid();
        }
    }
}

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
        public ValidationResponse ValidateInputNumbers(List<string> input)
        {
            if(input.Count() > 2)
            {
                return ValidationResponse.Invalid("Maximum two numbers allowed");
            }

            return ValidationResponse.Valid();
        }
    }
}

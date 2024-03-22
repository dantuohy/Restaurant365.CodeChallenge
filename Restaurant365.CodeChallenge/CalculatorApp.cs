using Restaurant365.CodeChallenge.Services;
using Restaurant365.CodeChallenge.Services.Interfaces;

namespace Restaurant365.CodeChallenge
{
    public class CalculatorApp
    {
        private readonly IValidationService _validationService;
        private readonly IInputConversionService _inputConversionService;
        private readonly ICalculatorService _calculatorService;
        private readonly ISplitService _splitService;

        public CalculatorApp(IValidationService validationService, IInputConversionService inputConversionService, ICalculatorService calculatorService, ISplitService splitService)
        {
            _validationService = validationService;
            _inputConversionService = inputConversionService;
            _calculatorService = calculatorService;
            _splitService = splitService;
        }
        public int Process(string input)
        {
            var validationResponse = _validationService.ValidateInput(input);

            if (!validationResponse.IsValid)
            {
                throw new Exception(validationResponse.Message);
            }

            var splitInput = _splitService.Split(input);

            var numbersToCalculate = _inputConversionService.Convert(splitInput);

            validationResponse = _validationService.ValidateInputNumbers(numbersToCalculate);

            if (!validationResponse.IsValid)
            {
                throw new Exception(validationResponse.Message);
            }

            return _calculatorService.Calculate(numbersToCalculate);
        }
    }
}

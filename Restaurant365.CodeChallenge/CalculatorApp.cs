using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge
{
    public class CalculatorApp
    {
        private ValidationService _validationService;
        private InputConversionService _inputConversionService;
        private CalculatorService _calculatorService;
        private SplitService _splitService;

        public CalculatorApp() 
        {
            _validationService = new ValidationService();
            _inputConversionService = new InputConversionService();
            _calculatorService = new CalculatorService();
            _splitService = new SplitService();
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

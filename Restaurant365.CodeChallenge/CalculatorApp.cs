using Restaurant365.CodeChallenge.Models;
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
        public CalculationResult Process(CalculationArguments arguments)
        {
            var validationResponse = _validationService.ValidateInput(arguments.Calculation);

            if (!validationResponse.IsValid)
            {
                throw new Exception(validationResponse.Message);
            }

            var splitInput = _splitService.Split(arguments.Calculation, arguments.CustomDelimiter);

            var numbersToCalculate = _inputConversionService.Convert(splitInput, arguments.UpperBound);

            validationResponse = _validationService.ValidateInputNumbers(numbersToCalculate, arguments.AllowNegatives);

            if (!validationResponse.IsValid)
            {
                throw new Exception(validationResponse.Message);
            }

            return new CalculationResult
            {
                Result = _calculatorService.Calculate(numbersToCalculate, arguments.Operator),
                Formula = _calculatorService.GetFormula(numbersToCalculate, arguments.Operator)
            };
        }
    }
}

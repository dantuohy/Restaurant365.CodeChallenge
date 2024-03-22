using Restaurant365.CodeChallenge.Models;
using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge.Tests
{
    internal class CalculatorAppTests
    {
        private CalculatorApp _calculatorApp;

        [SetUp]
        public void Setup()
        {
            _calculatorApp = new CalculatorApp(new ValidationService(), new InputConversionService(), new CalculatorService(), new SplitService());
        }

        [TestCase("20", ExpectedResult = 20)]
        [TestCase("1,1000", ExpectedResult = 1001)]
        [TestCase("2,1001,6", ExpectedResult = 1009)]
        [TestCase("1,1001", ExpectedResult = 1002)]
        [TestCase("sdfksdfsdfs", ExpectedResult = 0)]
        [TestCase("sdfksdfsdfs,1", ExpectedResult = 1)]
        [TestCase("1,sdfksdfsdfs", ExpectedResult = 1)]
        [TestCase("//#\n2#5", ExpectedResult = 7)]
        [TestCase("//,\n2,ff,100", ExpectedResult = 102)]
        [TestCase("//[***]\n11***22***33", ExpectedResult = 66)]
        [TestCase("//[*][!!][r9r]\n11r9r22*hh*33!!44", ExpectedResult = 110)]
        public int? GivenValidInputsReturnExpectedLength(string? numbers)
        {
            var arguments = new CalculationArguments
            {
                Calculation = numbers
            };

            return _calculatorApp.Process(arguments)?.Result;
        }

        [TestCase("20", "", false, int.MaxValue, ExpectedResult = 20)]
        [TestCase("20~1", "~", false, int.MaxValue, ExpectedResult = 21)]
        [TestCase("20~-1", "~", true, int.MaxValue, ExpectedResult = 19)]
        [TestCase("20", "", false, 10, ExpectedResult = 0)]
        [TestCase("20~1", "~", false, 10, ExpectedResult = 1)]
        [TestCase("20~-1", "~", true, int.MaxValue, ExpectedResult = 19)]
        [TestCase("//[***]\n11***22***33~1", "~", false, int.MaxValue, ExpectedResult = 67)]
        [TestCase("//[***]\n11***22***33~41", "~", false, 40, ExpectedResult = 66)]
        [TestCase("//[*][!!][r9r]\n11r9r22~1*hh*33!!44", "~", false, int.MaxValue, ExpectedResult = 111)]
        [TestCase("//[*][!!][r9r]\n11r9r22~51*hh*33!!44", "~", false, 50 , ExpectedResult = 110)]
        public int? GivenValidInputsWithArgumentsReturnsExpectedLength(string? numbers, string customDelimiter, bool allowNegatives, int upperBound)
        {
            var arguments = new CalculationArguments
            {
                Calculation = numbers,
                CustomDelimiter = customDelimiter,
                AllowNegatives  = allowNegatives,
                UpperBound = upperBound
            };

            return _calculatorApp.Process(arguments)?.Result;
        }

        public void GivenNullInput_ThrowsError()
        {
            Assert.Throws<Exception>(() => _calculatorApp.Process(null));
        }

        public void GivenEmptyInput_ThrowsError()
        {
            Assert.Throws<Exception>(() => _calculatorApp.Process(null));
        }

        public void GivenTooManyNumbers_ThrowsError()
        {
            var arguments = new CalculationArguments
            {
                Calculation = "1,2,3"
            };

            Assert.Throws<Exception>(() => _calculatorApp.Process(arguments));
        }
    }
}

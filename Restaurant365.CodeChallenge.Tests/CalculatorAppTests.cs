namespace Restaurant365.CodeChallenge.Tests
{
    internal class CalculatorAppTests
    {
        private CalculatorApp _calculatorApp;

        [SetUp]
        public void Setup()
        {
            _calculatorApp = new CalculatorApp();
        }

        [TestCase("20", ExpectedResult = 20)]
        [TestCase("1,5000", ExpectedResult = 5001)]
        [TestCase("sdfksdfsdfs", ExpectedResult = 0)]
        [TestCase("sdfksdfsdfs,1", ExpectedResult = 1)]
        [TestCase("1,sdfksdfsdfs", ExpectedResult = 1)]
        public int GivenValidInputsReturnExpectedLength(string? numbers)
        {
            return _calculatorApp.Process(numbers);
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
            Assert.Throws<Exception>(() => _calculatorApp.Process("1,2,3"));
        }
    }
}

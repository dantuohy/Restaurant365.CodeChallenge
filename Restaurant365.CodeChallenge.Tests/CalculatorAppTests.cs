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
        [TestCase("1,1000", ExpectedResult = 1001)]
        [TestCase("2,1001,6", ExpectedResult = 8)]
        [TestCase("1,1001", ExpectedResult = 1)]
        [TestCase("sdfksdfsdfs", ExpectedResult = 0)]
        [TestCase("sdfksdfsdfs,1", ExpectedResult = 1)]
        [TestCase("1,sdfksdfsdfs", ExpectedResult = 1)]
        [TestCase("//#\n2#5", ExpectedResult = 7)]
        [TestCase("//,\n2,ff,100", ExpectedResult = 102)]
        [TestCase("//[***]\n11***22***33", ExpectedResult = 66)]
        [TestCase("//[*][!!][r9r]\n11r9r22*hh*33!!44", ExpectedResult = 110)]
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

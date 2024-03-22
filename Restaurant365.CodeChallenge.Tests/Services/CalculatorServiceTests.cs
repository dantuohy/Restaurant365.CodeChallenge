using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge.Tests.Services
{
    internal class CalculatorServiceTests
    {
        private CalculatorService _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new CalculatorService();
        }

        [TestCase(new int[] { 20 }, ExpectedResult = 20)]
        [TestCase(new int[] { 1, 5000 }, ExpectedResult = 5001)]
        [TestCase(new int[] { 4, -3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int GivenValidInputsReturnExpectedResult(int[] numbers)
        {
            return _calculator.Calculate(numbers.ToList());
        }

        [TestCase(new int[] { 20 }, ExpectedResult = "20")]
        [TestCase(new int[] { 1, 5000 }, ExpectedResult = "1+5000")]
        [TestCase(new int[] { 4, -3 }, ExpectedResult = "4+-3")]
        [TestCase(new int[] { 1 }, ExpectedResult = "1")]
        [TestCase(new int[] { }, ExpectedResult = "")]
        [TestCase(new int[] { 1, 0 }, ExpectedResult = "1+0")]
        public string GivenValidInputsReturnExpectedFormula(int[] numbers)
        {
            return _calculator.GetFormula(numbers.ToList());
        }

        [Test]
        public void GivenNullInputReturnsZero()
        {
            Assert.That(_calculator.Calculate(null), Is.EqualTo(0));
        }
    }
}
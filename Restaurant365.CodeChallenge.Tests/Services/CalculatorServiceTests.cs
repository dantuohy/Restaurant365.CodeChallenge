using Restaurant365.CodeChallenge.Models;
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

        [TestCase(new int[] { 20 }, Operator.ADD, 20)]
        [TestCase(new int[] { 1, 5000 }, Operator.ADD, 5001)]
        [TestCase(new int[] { 4, -3 }, Operator.ADD, 1)]
        [TestCase(new int[] { 1 }, Operator.ADD, 1)]
        [TestCase(new int[] { }, Operator.ADD, 0)]
        [TestCase(new int[] { 20 }, Operator.SUBTRACT, 20)]
        [TestCase(new int[] { 1, 5000 }, Operator.SUBTRACT, -4999)]
        [TestCase(new int[] { 4, 3 }, Operator.SUBTRACT, 1)]
        [TestCase(new int[] { 4, -3 }, Operator.SUBTRACT, 7)]
        [TestCase(new int[] { 20 }, Operator.MULTIPLY, 20)]
        [TestCase(new int[] { 1, 5000 }, Operator.MULTIPLY, 5000)]
        [TestCase(new int[] { 4, 3 }, Operator.MULTIPLY, 12)]
        [TestCase(new int[] { 4, -3 }, Operator.MULTIPLY, -12)]
        [TestCase(new int[] { 20 }, Operator.DIVIDE, 20)]
        [TestCase(new int[] { 1, 5000 }, Operator.DIVIDE, 0.0002)]
        [TestCase(new int[] { 4, -3 }, Operator.DIVIDE, -1.3333)]
        [TestCase(new int[] { 4, 1 }, Operator.DIVIDE, 4)]
        public void GivenValidInputsReturnExpectedResult(int[] numbers, Operator operation, decimal expectedResult)
        {
            var roundedExpectedValue = decimal.Round(expectedResult, 4, MidpointRounding.AwayFromZero);
            var roundedActualValue = decimal.Round(_calculator.Calculate(numbers.ToList(), operation), 4, MidpointRounding.AwayFromZero);
            Assert.That(roundedActualValue, Is.EqualTo(roundedExpectedValue));
        }

        [TestCase(new int[] { 20 }, Operator.ADD, ExpectedResult = "20")]
        [TestCase(new int[] { 1, 5000 }, Operator.ADD, ExpectedResult = "1+5000")]
        [TestCase(new int[] { 4, -3 }, Operator.ADD, ExpectedResult = "4+-3")]
        [TestCase(new int[] { 1 }, Operator.ADD, ExpectedResult = "1")]
        [TestCase(new int[] { }, Operator.ADD, ExpectedResult = "")]
        [TestCase(new int[] { 1, 0 }, Operator.ADD, ExpectedResult = "1+0")]
        [TestCase(new int[] { 1, 0 }, Operator.SUBTRACT, ExpectedResult = "1-0")]
        [TestCase(new int[] { 1, 0 }, Operator.MULTIPLY, ExpectedResult = "1*0")]
        [TestCase(new int[] { 1, 1 }, Operator.DIVIDE, ExpectedResult = "1/1")]
        public string GivenValidInputsReturnExpectedFormula(int[] numbers, Operator operation)
        {
            return _calculator.GetFormula(numbers.ToList(), operation);
        }

        [TestCase(Operator.ADD)]
        [TestCase(Operator.SUBTRACT)]
        [TestCase(Operator.MULTIPLY)]
        [TestCase(Operator.DIVIDE)]
        public void GivenNullInputReturnsZero(Operator operation)
        {
            Assert.That(_calculator.Calculate(null, operation), Is.EqualTo(0));
        }
    }
}
using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge.Tests.Services
{
    internal class InputConversionServiceTests
    {
        private InputConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            _conversionService = new InputConversionService();
        }

        [TestCase(new string[] { "20" }, new int[] { 20 })]
        [TestCase(new string[] { "1", "5000" }, new int[] { 1, 5000 })]
        [TestCase(new string[] { "4", "-3" }, new int[] { 4, -3 })]
        [TestCase(new string[] { "1" }, new int[] { 1 })]
        [TestCase(new string[] { "gfhdfghd", "-3" }, new int[] { 0, -3 })]
        [TestCase(new string[] { "fdgdf" }, new int[] { 0 })]
        [TestCase(new string[] { "4", "fgdgf" }, new int[] { 4, 0 })]
        [TestCase(new string[] { }, new int[] { })]
        public void GivenValidInputsReturnExpectedResult(string[] numbers, int[] expectedResult)
        {
            Assert.That(_conversionService.Convert(numbers.ToList()), Is.EqualTo(expectedResult));
        }
    }
}

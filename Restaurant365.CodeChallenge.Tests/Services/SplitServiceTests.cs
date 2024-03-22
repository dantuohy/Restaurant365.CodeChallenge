using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge.Tests.Services
{
    internal class SplitServiceTests
    {
        private SplitService _splitService;

        [SetUp]
        public void Setup()
        {
            _splitService = new SplitService();
        }

        [TestCase("20", ExpectedResult = 1)]
        [TestCase("1,5000", ExpectedResult = 2)]
        [TestCase("1,5000,343", ExpectedResult = 3)]
        [TestCase("sdfksdfsdfs", ExpectedResult = 1)]
        [TestCase("1\n5000", ExpectedResult = 2)]
        [TestCase("1,5000\n343", ExpectedResult = 3)]
        [TestCase("1\n5000,343", ExpectedResult = 3)]
        [TestCase("1\\n5000", ExpectedResult = 2)]
        [TestCase("1,5000\\n343", ExpectedResult = 3)]
        [TestCase("1\\n5000,343", ExpectedResult = 3)]
        [TestCase(null, ExpectedResult = 0)]
        public int GivenValidInputsReturnExpectedLength(string? numbers)
        {
            return _splitService.Split(numbers).Count();
        }

        [TestCase("20", new string[] { "20" })]
        [TestCase("1,5000", new string[] { "1", "5000" })]
        [TestCase("1,5000,343", new string[] { "1", "5000", "343" })]
        [TestCase("sdfksdfsdfs", new string[] { "sdfksdfsdfs" })]
        [TestCase("1\n5000", new string[] { "1", "5000" })]
        [TestCase("1,5000\n343", new string[] { "1", "5000", "343" })]
        [TestCase("1\n5000,343", new string[] { "1", "5000", "343" })]
        [TestCase("1\\n5000", new string[] { "1", "5000" })]
        [TestCase("1,5000\\n343", new string[] { "1", "5000", "343" })]
        [TestCase("1\\n5000,343", new string[] { "1", "5000", "343" })]
        [TestCase(null, new string[] { })]
        public void GivenValidInputsReturnExpectedItems(string? numbers, string[] expectedResult)
        {
            Assert.IsTrue(_splitService.Split(numbers).SequenceEqual(expectedResult));

        }
    }
}

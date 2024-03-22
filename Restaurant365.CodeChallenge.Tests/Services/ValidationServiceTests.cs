using Restaurant365.CodeChallenge.Services;

namespace Restaurant365.CodeChallenge.Tests.Services
{
    internal class ValidationServiceTests
    {
        private ValidationService _validationService;

        [SetUp]
        public void Setup()
        {
            _validationService = new ValidationService();
        }

        [Test]
        public void GivenTestingValidateInputs_AndInputIsValid_ReturnExpectedResult()
        {
            var response = _validationService.ValidateInput("20");
            Assert.IsTrue(response.IsValid);
            Assert.IsNull(response.Message);
        }

        [Test]
        public void GivenTestingValidateInputs_AndInputNull_ReturnExpectedResult()
        {
            var response = _validationService.ValidateInput(null);
            Assert.IsFalse(response.IsValid);
            Assert.IsNotNull(response.Message);
        }

        [Test]
        public void GivenTestingValidateInputs_AndInputEmpty_ReturnExpectedResult()
        {
            var response = _validationService.ValidateInput("");
            Assert.IsFalse(response.IsValid);
            Assert.IsNotNull(response.Message);
        }

        [Test]
        public void GivenTestingValidateInputsNumbers_AndNegativeNumber_ReturnExpectedResult()
        {
            var response = _validationService.ValidateInputNumbers([0, 1, -1]);
            Assert.IsFalse(response.IsValid);
            Assert.IsNotNull(response.Message);
            Assert.IsTrue(response.Message.Contains("-1"));
        }

        [Test]
        public void GivenTestingValidateInputsNumbers_AndNegativeNumbers_ReturnExpectedResult()
        {
            var response = _validationService.ValidateInputNumbers([-2, 0, 1, -1]);
            Assert.IsFalse(response.IsValid);
            Assert.IsNotNull(response.Message);
            Assert.IsTrue(response.Message.Contains("-1"));
            Assert.IsTrue(response.Message.Contains("-2"));
        }
    }
}

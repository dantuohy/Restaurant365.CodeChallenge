using Restaurant365.CodeChallenge.Models;

namespace Restaurant365.CodeChallenge.Tests.Models
{
    internal class ValidationResponseTests
    {
        [Test]
        public void GivenValidReturnsIsValidTrue()
        {
            var validationResponse = ValidationResponse.Valid();
            Assert.That(validationResponse.IsValid, Is.True);
            Assert.IsNull(validationResponse.Message);
        }

        [Test]
        public void GivenInvalidReturnsInvalidWithMessage()
        {
            var message = "a test message";
            var validationResponse = ValidationResponse.Invalid(message);
            Assert.That(validationResponse.IsValid, Is.False);
            Assert.That(validationResponse.Message, Is.EqualTo(message));
        }
    }
}


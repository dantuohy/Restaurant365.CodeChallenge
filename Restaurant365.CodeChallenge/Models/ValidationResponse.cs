namespace Restaurant365.CodeChallenge.Models
{
    public class ValidationResponse
    {
        public bool IsValid { get; private set; }
        public string? Message { get; private set; }

        public static ValidationResponse Valid()
        {
            return new ValidationResponse { IsValid = true };
        }
        public static ValidationResponse Invalid(string message)
        {
            return new ValidationResponse { IsValid = false, Message = message };
        }
    }
}

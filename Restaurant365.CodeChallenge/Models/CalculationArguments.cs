namespace Restaurant365.CodeChallenge.Models
{
    public class CalculationArguments
    {
        public string? Calculation;
        public string? CustomDelimiter;
        public bool AllowNegatives;
        public int UpperBound = int.MaxValue;
    }
}

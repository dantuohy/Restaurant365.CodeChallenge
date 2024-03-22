namespace Restaurant365.CodeChallenge.Models
{
    public class CalculationArguments
    {
        public Operator Operator = Operator.ADD;
        public string? Calculation;
        public string? CustomDelimiter;
        public bool AllowNegatives;
        public int UpperBound = int.MaxValue;
    }
}

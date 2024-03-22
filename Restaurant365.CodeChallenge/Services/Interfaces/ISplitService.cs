namespace Restaurant365.CodeChallenge.Services.Interfaces
{
    public interface ISplitService
    {
        List<string> Split(string input);
        List<string> Split(string input, string? customDelimiter);
    }
}

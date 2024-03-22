namespace Restaurant365.CodeChallenge.Services
{
    public class SplitService
    {
        public List<string> Split(string input)
        {
            return input == null ? new List<string>() : input.Split([",", "\\n", "\n"], StringSplitOptions.None).ToList();
        }
    }
}

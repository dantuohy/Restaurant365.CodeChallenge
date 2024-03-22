using System.Text.RegularExpressions;

namespace Restaurant365.CodeChallenge.Services
{
    public class SplitService
    {
        public List<string> Split(string input)
        {
            if(input == null)
            {
                return new List<string>();
            }

            var delimiters = new List<string> { ",", "\\n", "\n" };
            var customDelimiter = Regex.Match(input, @"(?<=//\[).*(?=\])");

            if (customDelimiter.Success)
            {
                delimiters.Add(customDelimiter.Groups[0].Value);
                input = input.Split(["\\n", "\n"], StringSplitOptions.None)[1];
            }
            else
            {
                customDelimiter = Regex.Match(input, @"(?<=//).*(?=\n|\\n)");
                if (customDelimiter.Success)
                {
                    delimiters.Add(customDelimiter.Groups[0].Value);
                    input = input.Split(["\\n", "\n"], StringSplitOptions.None)[1];
                }
            }

            return input.Split(delimiters.ToArray(), StringSplitOptions.None).ToList();
        }
    }
}

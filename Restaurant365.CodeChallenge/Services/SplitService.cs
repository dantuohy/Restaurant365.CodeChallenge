using Restaurant365.CodeChallenge.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant365.CodeChallenge.Services
{
    public class SplitService : ISplitService
    {
        public List<string> Split(string input)
        {
            if(input == null)
            {
                return new List<string>();
            }

            var delimiters = new List<string> { ",", "\\n", "\n" };
            var matches = Regex.Matches(input, @"\[(.*?)\]");

            if (matches.Any())
            {
                foreach (Match match in matches)
                {
                    delimiters.Add(match.Groups[1].Value);
                }
                input = input.Split(["\\n", "\n"], StringSplitOptions.None)[1];
            }
            else
            {
                var match = Regex.Match(input, @"(?<=//).*(?=\n|\\n)");
                if (match.Success)
                {
                    delimiters.Add(match.Groups[0].Value);
                    input = input.Split(["\\n", "\n"], StringSplitOptions.None)[1];
                }
            }

            return input.Split(delimiters.ToArray(), StringSplitOptions.None).ToList();
        }
    }
}

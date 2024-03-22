namespace Restaurant365.CodeChallenge.Services
{
    public class InputConversionService
    {
        public List<int> Convert(List<string> inputData)
        {
            return inputData.Select(x =>
            {
                var result = 0;
                return int.TryParse(x, out result) ? result : 0;
            }).ToList();
        }
    }
}

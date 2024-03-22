using Restaurant365.CodeChallenge.Services.Interfaces;

namespace Restaurant365.CodeChallenge.Services
{
    public class InputConversionService : IInputConversionService
    {
        public List<int> Convert(List<string> inputData, int limit = 1000)
        {
            return inputData.Select(x =>
            {
                var result = 0;
                return int.TryParse(x, out result) ? result <= limit ? result : 0 : 0;
            }).ToList();
        }
    }
}

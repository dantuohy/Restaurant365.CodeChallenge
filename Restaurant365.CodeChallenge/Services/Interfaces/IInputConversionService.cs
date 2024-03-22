namespace Restaurant365.CodeChallenge.Services.Interfaces
{
    public interface IInputConversionService
    {
        List<int> Convert(List<string> inputData, int limit = 1000);
    }
}

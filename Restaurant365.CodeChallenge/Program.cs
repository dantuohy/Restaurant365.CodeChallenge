namespace Restaurant365.CodeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorApp app = new CalculatorApp();

            Console.WriteLine("Provide your calculation");

            var calculation = Console.ReadLine();

            var calculationResult = app.Process(calculation);

            Console.WriteLine($"Result: {calculationResult}");
        }
    }
}

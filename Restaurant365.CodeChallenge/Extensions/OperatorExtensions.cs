using Restaurant365.CodeChallenge.Models;

namespace Restaurant365.CodeChallenge.Extensions
{
    public static class OperatorExtensions
    {
        public static string GetOperator(this Operator operation)
        {
            switch (operation)
            {
                case Operator.ADD:
                    return "+";
                 case Operator.SUBTRACT: 
                    return "-";
                 case Operator.MULTIPLY: 
                    return "*";
                 case Operator.DIVIDE: 
                    return "/";
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation));
            }
        }

        public static Operator? StringToOperator(string? operatorInput)
        {
            if(operatorInput == "+")
            {
                return Operator.ADD;
            }
            if (operatorInput == "-")
            {
                return Operator.SUBTRACT;
            }
            if (operatorInput == "*")
            {
                return Operator.MULTIPLY;
            }
            if (operatorInput == "/")
            {
                return Operator.DIVIDE;
            }

            return null;
            
        }
    }
}

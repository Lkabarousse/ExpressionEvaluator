namespace ExpressionEvaluator.Interfaces
{
    public interface IOperator
    {
        int Apply(int leftOperand, int rightOperand);
    }

    public class AdditionOperator : IOperator
    {
        public int Apply(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }

    public class SubtractionOperator : IOperator
    {
        public int Apply(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }

    public class MultiplicationOperator : IOperator
    {
        public int Apply(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}

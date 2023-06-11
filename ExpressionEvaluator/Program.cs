namespace ExpressionEvaluator
{
    using global::ExpressionEvaluator.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, IOperator> operators = new()
            {
            { "+", new AdditionOperator() },
            { "-", new SubtractionOperator() },
            { "*", new MultiplicationOperator() }
            };

            ExpressionEvaluator evaluator = new(operators);

            string[] expressions = new string[]
            {
            "1 + 2",
            "3 * 4",
            "11 - 2",
            "2 * 3 - 1",
            "6 - 2 * 5"
            };

            foreach (string expression in expressions)
            {
                int result = evaluator.Evaluate(expression);
                Console.WriteLine($"Expression: {expression} = {result}");
            }
        }
    }

}

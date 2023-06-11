namespace ExpressionEvaluator
{
    using global::ExpressionEvaluator.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            // Creates a dictionary to map string symbols to their respective operator classes. 
            // The operator classes implement the IOperator interface.

            Dictionary<string, IOperator> operators = new()
            {
            { "+", new AdditionOperator() },
            { "-", new SubtractionOperator() },
            { "*", new MultiplicationOperator() }
            };

            // Initializes an instance of the ExpressionEvaluator class, passing the operators dictionary as a parameter.
            ExpressionEvaluator evaluator = new(operators);

            // Defines an array of string expressions to evaluate.

            string[] expressions = new string[]
            {
            "1 + 2",
            "3 * 4",
            "11 - 2",
            "2 * 3 - 1",
            "6 - 2 * 5"
            };

            // For each expression in the expressions array,
            // the expression is evaluated and the result is printed to the console.

            foreach (string expression in expressions)
            {
                int result = evaluator.Evaluate(expression);
                Console.WriteLine($"Expression: {expression} = {result}");
            }
        }
    }

}

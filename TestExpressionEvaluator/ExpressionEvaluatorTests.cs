using ExpressionEvaluator.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace TestExpressionEvaluator
{
    public class ExpressionEvaluatorTests
    {
        [Fact]
        public void Evaluate_AdditionExpression_ReturnsCorrectResult()
        {
            // Arrange
            ExpressionEvaluator.ExpressionEvaluator evaluator = CreateEvaluator();
            string expression = "1 + 2";

            // Act
            int result = evaluator.Evaluate(expression);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Evaluate_MultiplicationExpression_ReturnsCorrectResult()
        {
            // Arrange
            ExpressionEvaluator.ExpressionEvaluator evaluator = CreateEvaluator();
            string expression = "3 * 4";

            // Act
            int result = evaluator.Evaluate(expression);

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void Evaluate_SubtractionExpression_ReturnsCorrectResult()
        {
            // Arrange
            ExpressionEvaluator.ExpressionEvaluator evaluator = CreateEvaluator();
            string expression = "11 - 2";

            // Act
            int result = evaluator.Evaluate(expression);

            // Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void Evaluate_MixedExpression_ReturnsCorrectResult()
        {
            // Arrange
            ExpressionEvaluator.ExpressionEvaluator evaluator = CreateEvaluator();
            string expression = "2 * 3 - 1";

            // Act
            int result = evaluator.Evaluate(expression);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Evaluate_ComplexExpression_ReturnsCorrectResult()
        {
            // Arrange
            ExpressionEvaluator.ExpressionEvaluator evaluator = CreateEvaluator();
            string expression = "6 - 2 * 5";

            // Act
            int result = evaluator.Evaluate(expression);

            // Assert
            Assert.Equal(-4, result);
        }

        private static ExpressionEvaluator.ExpressionEvaluator CreateEvaluator()
        {
            Dictionary<string, IOperator> operators = new()
            {
            { "+", new AdditionOperator() },
            { "-", new SubtractionOperator() },
            { "*", new MultiplicationOperator() }
        };

            return new ExpressionEvaluator.ExpressionEvaluator(operators);
        }
    }
}

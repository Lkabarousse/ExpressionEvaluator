using ExpressionEvaluator.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    public class ExpressionEvaluator
    {
        private readonly Dictionary<string, IOperator> operators;

        public ExpressionEvaluator(Dictionary<string, IOperator> operators)
        {
            this.operators = operators;
        }

        public int Evaluate(string expression)
        {
            string[] tokens = expression.Split(' ');

            Stack<int> operandStack = new();
            Stack<string> operatorStack = new();

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                if (operators.ContainsKey(token))
                {
                    while (operatorStack.Count > 0 && operators.ContainsKey(operatorStack.Peek()) && HasPrecedence(operatorStack.Peek(), token))
                    {
                        ApplyOperator(operandStack, operatorStack);
                    }

                    operatorStack.Push(token);
                }
                else
                {
                    operandStack.Push(int.Parse(token));
                }
            }

            while (operatorStack.Count > 0)
            {
                ApplyOperator(operandStack, operatorStack);
            }

            return operandStack.Pop();
        }

        private static bool HasPrecedence(string op1, string op2)
        {
            if (op1 == "*" && op2 == "+")
                return true;
            if (op1 == "*" && op2 == "-")
                return true;
            return false;
        }

        private void ApplyOperator(Stack<int> operandStack, Stack<string> operatorStack)
        {
            string op = operatorStack.Pop();
            int rightOperand = operandStack.Pop();
            int leftOperand = operandStack.Pop();

            IOperator @operator = operators[op];
            int result = @operator.Apply(leftOperand, rightOperand);

            operandStack.Push(result);
        }
    }
}

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

        // This public method takes in an arithmetic expression as a string and evaluates it, returning the result as an integer.
        public int Evaluate(string expression)
        {
            // Split the input expression string into an array of tokens, divided by the space character ' '.
            string[] tokens = expression.Split(' ');

            // Initialize an empty stack for operands (numbers).
            Stack<int> operandStack = new();

            // Initialize an empty stack for operators (like +, -, *).
            Stack<string> operatorStack = new();

            // For each token in the token array
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                // If the token is an operator
                if (operators.ContainsKey(token))
                {
                    // While there's at least one operator on the operator stack, 
                    // and the top operator on the stack has equal or greater precedence than the current token
                    while (operatorStack.Count > 0 && operators.ContainsKey(operatorStack.Peek()) && HasPrecedence(operatorStack.Peek(), token))
                    {
                        // Apply the top operator in the stack to the top two numbers in the operand stack.
                        ApplyOperator(operandStack, operatorStack);
                    }

                    // Push the current operator token onto the operator stack.
                    operatorStack.Push(token);
                }
                else
                {
                    // If the token is a number, push it onto the operand stack.
                    operandStack.Push(int.Parse(token));
                }
            }

            // If there are any operators left in the operator stack, apply them to the operand stack.
            while (operatorStack.Count > 0)
            {
                ApplyOperator(operandStack, operatorStack);
            }

            // The final result of the expression will be the last remaining number on the operand stack.
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

        // This method applies an operator to two operands.
        // It pops an operator from the operator stack, and two operands from the operand stack.
        // It then applies the operator to the operands and pushes the result back onto the operand stack.
        private void ApplyOperator(Stack<int> operandStack, Stack<string> operatorStack)
        {
            // Pop the top operator from the operator stack.
            string op = operatorStack.Pop();

            // Pop the top two numbers from the operand stack. 
            // The number on the top of the stack is the right operand, and the next one is the left operand.
            int rightOperand = operandStack.Pop();
            int leftOperand = operandStack.Pop();

            // Get the IOperator instance that corresponds to the operator string (e.g., '+', '-', '*')
            IOperator @operator = operators[op];

            // Apply the operator to the operands. The specific operation is determined by which class of IOperator is used.
            int result = @operator.Apply(leftOperand, rightOperand);

            // Push the result back onto the operand stack. This result can now be used as an operand for a future operator.
            operandStack.Push(result);
        }
    }

}

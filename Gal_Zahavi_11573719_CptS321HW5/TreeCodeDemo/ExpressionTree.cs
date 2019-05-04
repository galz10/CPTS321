// <copyright file="ExpressionTree.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]

    /// <summary>
    /// expression tree class
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Name:Expresison
        /// Description:a string value that gets set to the expression
        /// </summary>
        public string Expression;

        /// <summary>
        /// Name:variables
        /// Description:a dictionary of variables to store the variables in 
        /// </summary>
        protected Dictionary<string, double> variables;

        /// <summary>
        /// Name:root
        /// Description: a basenode root
        /// </summary>
        private BasicNode root;

        /// <summary>
        /// Name:ExpressionTree
        /// Description:Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="inputedExpression">inputed expression by user or hardcoded if user doesn't set it to anything</param>
        public ExpressionTree(string inputedExpression)
        {
            this.root = Compile(inputedExpression);
            this.variables = new Dictionary<string, double>();
            this.Expression = inputedExpression;
        }

        /// <summary>
        /// Name:SetVariable
        /// Description:sets the name and value to a variable
        /// </summary>
        /// <param name="inputedVariableName">inputed variable name that needs to be set</param>
        /// <param name="inputedVariableValue">inputed value that needs to be set to a variable</param>
        public void SetVariable(string inputedVariableName, double inputedVariableValue)
        {
            this.variables[inputedVariableName] = inputedVariableValue;
        }

        /// <summary>
        /// Name:Evaluate
        /// Description: sets up a public evaluate root functions
        /// </summary>
        /// <returns>returns a double of the evaluated expression</returns>
        public double Evaluate()
        {
            return this.Evaluate(this.root);
        }

        /// <summary>
        /// Name:BuildVNode
        /// Description:Builds the variable node
        /// </summary>
        /// <param name="variable">the variable that needs to be set</param>
        /// <returns>returns a basenode of the variable</returns>
        private static BasicNode BuildVNode(string variable)
        {
            double num;
            if (double.TryParse(variable, out num))
            {
                return new ConstantNode(num);
            }

            VariableNode node = new VariableNode(variable);
            return new VariableNode(variable);
        }

        /// <summary>
        /// Name:Compile
        /// Description:Compiles the expression
        /// </summary>
        /// <param name="expression">inputed expression</param>
        /// <returns>returns the basenode of the expression tree</returns>
        private static BasicNode Compile(string expression)
        {
            if (expression.Length != 0)
            {
                int operatorIndex = expression.Length - 1;
                while (operatorIndex > 0 && !ExpressionTreeFactory.IsValidOperator(expression[operatorIndex]))
                {
                    operatorIndex--;
                }

                if (ExpressionTreeFactory.IsValidOperator(expression[operatorIndex]))
                {
                    OperatorNode newNode = ExpressionTreeFactory.CreateOperatorNode(expression[operatorIndex]);
                    newNode.Left = Compile(expression.Substring(0, operatorIndex));
                    newNode.Right = Compile(expression.Substring(operatorIndex + 1));

                    return newNode;
                }

                double number;
                if (double.TryParse(expression, out number))
                {
                    ConstantNode newNode = new ConstantNode(number);

                    return newNode;
                }
                else
                {
                    VariableNode newNode = new VariableNode(expression);
                    return newNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:Evaluates the expression tree
        /// </summary>
        /// <param name="node">inputed node of the expression tree</param>
        /// <returns>returns a double of the evaluated expression</returns>
        private double Evaluate(BasicNode node)
        {
            if (node != null && node is OperatorNode)
            {
                OperatorNode temp = (OperatorNode)node;

                return temp.Evaluate(this.Evaluate(temp.Left), this.Evaluate(temp.Right));
            }

            if (node != null && node is VariableNode)
            {
                try
                {
                    return this.variables[node.Name];
                }
                catch
                {
                    throw new System.ArgumentException("Variable " + node.Name + " has not been defined.", "Variable Not Defined");
                }
            }

            if (node != null && node is ConstantNode)
            {
                ConstantNode temp = (ConstantNode)node;
                return temp.OperatorValue;
            }

            return 0;
        }
    }
}
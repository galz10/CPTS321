// <copyright file="ExpressionTree.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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
        protected Dictionary<string, double> variables = new Dictionary<string, double>();

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
            this.root = this.Compile(inputedExpression);
            this.Expression = inputedExpression;
        }

        /// <summary>
        /// Name:GetLowestInheritanceIndex
        /// Description:gets the index of the lowest presedence operator
        /// </summary>
        /// <param name="expression">the inputed expression</param>
        /// <returns>returns the index of the operator</returns>
        public static int GetLowestOperatorInheritanceIndex(string expression)
        {
            int parenthesisCounter = 0, operatorIndex = -1, i = expression.Length - 1;
            for (; i >= 0; i--)
            {
                switch (expression[i])
                {
                    case '+':
                    case '-':
                        if (parenthesisCounter == 0)
                        {
                            return i;
                        }

                        break;
                    case '*':
                    case '/':
                        if (parenthesisCounter == 0 && operatorIndex == -1)
                        {
                            operatorIndex = i;
                        }

                        break;
                    case '(':
                        parenthesisCounter++;
                        break;
                    case ')':
                        parenthesisCounter--;
                        break;
                }
            }

            if (parenthesisCounter == 0)
            {
                return operatorIndex;
            }
            else
            {
                throw new System.ArgumentException("Too many or too few parentheses", "Invalid Expression");
            }
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
            if (this.root != null)
            {
                return this.Evaluate(this.root);
            }
            else
            {
                return double.NaN;
            }
        }

        /// <summary>
        /// Name:GetVariable
        /// Description:Gets the varivbles and returns them in an array
        /// </summary>
        /// <returns>returns the variables in an array</returns>
        public string[] GetVariable()
        {
            return this.variables.Keys.ToArray();
        }

        /// <summary>
        /// Name:BuildVNode
        /// Description:Builds the variable node
        /// </summary>
        /// <param name="variable">the variable that needs to be set</param>
        /// <returns>returns a basenode of the variable</returns>
        private BasicNode BuildVNode(string variable)
        {
            double num;
            if (double.TryParse(variable, out num))
            {
                return new ConstantNode(num);
            }

            this.SetVariable(variable, 0);
            return new VariableNode(variable);
        }

        /// <summary>
        /// Name:Compile
        /// Description:Compiles the expression
        /// </summary>
        /// <param name="expression">inputed expression</param>
        /// <returns>returns the basenode of the expression tree</returns>
        private BasicNode Compile(string expression)
        {
            expression = expression.Replace(" ", string.Empty);
            int counter = 1, i = 0;
            if (expression[i] == '(')
            {
                for (i = 1; expression.Length > i; i++)
                {
                    if (expression[i] == '(')
                    {
                        counter++;
                    }
                    else if (expression[i] == ')')
                    {
                        counter--;
                        if (counter == 0)
                        {
                            if (i == expression.Length - 1)
                            {
                                return this.Compile(expression.Substring(1, expression.Length - 2));
                            }

                            break;
                        }
                    }
                }

                if (counter != 0)
                {
                    throw new System.ArgumentException("Too many or too few parentheses", "Invalid Expression");
                }
            }

            int index = GetLowestOperatorInheritanceIndex(expression);
            if (index != -1)
            {
                OperatorNode node = ExpressionTreeFactory.CreateOperatorNode(expression[index]);
                node.Right = this.Compile(expression.Substring(index + 1));
                node.Left = this.Compile(expression.Substring(0, index));
                return node;
            }
            else if (index == -2)
            {
                throw new System.ArgumentException("Too many or too few parentheses", "Invalid Expression");
            }

            return this.BuildVNode(expression);
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:Evaluates the expression tree
        /// </summary>
        /// <param name="node">inputed node of the expression tree</param>
        /// <returns>returns a double of the evaluated expression</returns>
        private double Evaluate(BasicNode node)
        {
            ConstantNode constnode = node as ConstantNode;
            if (constnode != null)
            {
                return constnode.OperatorValue;
            }

            VariableNode varnode = node as VariableNode;
            if (varnode != null)
            {
                // used to be a try/catch, but now we set every new variable to 0 when the tree is made, so there will always be a value to obtain.
                return this.variables[varnode.Name];
            }

            OperatorNode opnode = node as OperatorNode;
            if (opnode != null)
            {
                return opnode.Evaluate(this.Evaluate(opnode.Left), this.Evaluate(opnode.Right));
            }

            return 0;
        }
    }
}
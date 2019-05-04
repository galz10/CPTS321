// <copyright file="ExpressionTreeFactory.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
   
    /// <summary>
    /// expression tree factory
    /// </summary>
    internal class ExpressionTreeFactory
    {
        /// <summary>
        /// Name:CreateOperatorNode
        /// Description:creates the operator node to evaluate the expression
        /// </summary>
        /// <param name="operators">inputed operator</param>
        /// <returns>operator node</returns>
        public static OperatorNode CreateOperatorNode(char operators)
        {
            switch (operators)
            {
                case '-':
                    return new MinusNode();
                case '+':
                    return new PlusNode();
                case '*':
                    return new MultiplyNode();
                case '/':
                    return new DivideNode();
            }

            return null;
        }

        /// <summary>
        /// Name:IsValidOperator
        /// Description:Checks if the operator is valid
        /// </summary>
        /// <param name="operators">the inputed operator</param>
        /// <returns>a bool if the operator is valid</returns>
        public static bool IsValidOperator(char operators)
        {
            switch (operators)
            {
                case '-':
                    return true;
                case '+':
                    return true;
                case '*':
                    return true;
                case '/':
                    return true;
            }

            return false;
        }
    }
}

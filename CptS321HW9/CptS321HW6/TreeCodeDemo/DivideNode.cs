// <copyright file="DivideNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// divided node class
    /// </summary>
    internal class DivideNode : OperatorNode
    {
        /// <summary>
        /// Name:DivideNode
        /// Description:Initializes a new instance of the <see cref="DivideNode"/> class.
        /// </summary>
        public DivideNode() : base('/')
        {
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:overrided function to evaluate left and right to divide tem
        /// </summary>
        /// <param name="left">left double</param>
        /// <param name="right">right double</param>
        /// <returns>left divided by right</returns>
        public override double Evaluate(double left, double right)
        {
            return left / right;
        }
    }
}

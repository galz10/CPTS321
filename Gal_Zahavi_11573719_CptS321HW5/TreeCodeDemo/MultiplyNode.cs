// <copyright file="MultiplyNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// multiply node class
    /// </summary>
    internal class MultiplyNode : OperatorNode
    {
        /// <summary>
        /// Name:MultiplyNode
        /// Description:Initializes a new instance of the <see cref="MultiplyNode"/> class.
        /// </summary>
        public MultiplyNode() : base('*')
        {
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:multiplies the left and right double
        /// </summary>
        /// <param name="left">left double</param>
        /// <param name="right">right double</param>
        /// <returns>the multiplied the left and right double</returns>
        public override double Evaluate(double left, double right)
        {
            return left * right;
        }
    }
}

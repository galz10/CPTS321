// <copyright file="PlusNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>

namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Plus node class that inherites from operator node
    /// </summary>
    internal class PlusNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlusNode"/> class.
        /// </summary>
        public PlusNode() : base('+')
        {
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:override the evaluate function to add left and right
        /// </summary>
        /// <param name="left">left double</param>
        /// <param name="right">right double</param>
        /// <returns>sum of left and right</returns>
        public override double Evaluate(double left, double right)
        {
            return left + right;
        }
    }
}

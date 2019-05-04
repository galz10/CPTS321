// <copyright file="MinusNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// minus node 
    /// </summary>
    internal class MinusNode : OperatorNode
    {
        /// <summary>
        /// Name:MinusNode
        /// Description:Initializes a new instance of the <see cref="MinusNode"/> class.
        /// </summary>
        public MinusNode() : base('-')
        {
        }

        /// <summary>
        /// Name:Evaluate
        /// Description:overrided function to be able to subtract a left and right number
        /// </summary>
        /// <param name="left">a left double</param>
        /// <param name="right">a right double</param>
        /// <returns>returns the left minus right double</returns>
        public override double Evaluate(double left, double right)
        { 
            return left - right;
        }
    }
}

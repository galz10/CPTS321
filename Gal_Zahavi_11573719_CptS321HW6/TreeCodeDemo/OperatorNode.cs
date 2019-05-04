// <copyright file="OperatorNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Name:
    /// Description:
    /// </summary>
    internal abstract class OperatorNode : BasicNode
    {
        /// <summary>
        /// Name:
        /// Description:
        /// </summary>
        private char operate;

        /// <summary>
        /// Name:
        /// Description:
        /// </summary>
        private BasicNode left, right;

        /// <summary>
        /// Name:
        /// Description:
        /// </summary>
        private char value;

        /// <summary>
        /// Name:OperatorNode
        /// Description: Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="inputedOp">inputed operator</param>
        /// <param name="left">left node</param>
        /// <param name="right">right node</param>
        public OperatorNode(char inputedOp, BasicNode left, BasicNode right)
        {
            this.operate = inputedOp;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Name:OperatorNode
        /// Description:Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="inputedValue">inputed value</param>
        public OperatorNode(char inputedValue)
        {
            this.value = inputedValue;
        }

        /// <summary>
        /// Gets the operator
        /// </summary>
        public char Operator
        {
            get
            {
                return this.operate;
            }
        }

        /// <summary>
        /// Gets or sets the left basic node
        /// </summary>
        public BasicNode Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// Gets or sets the right basic node
        /// </summary>
        public BasicNode Right
        {
            get
            {
                return this.right;
            }

            set
            {
                this.right = value;
            }
        }
        /// <summary>
        /// Name:Evaluate
        /// Description:returns a double of the evaluated expression
        /// </summary>
        /// <param name="left">left double</param>
        /// <param name="right">right double</param>
        /// <returns>returns a double</returns>
        public abstract double Evaluate(double left, double right);
    }
}
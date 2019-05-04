// <copyright file="NodeClass.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW11
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Node class
    /// </summary>
    public class Node
    {
        /// <summary>
        /// data integer
        /// </summary>
        private int data;

        /// <summary>
        /// left and right nodes
        /// </summary>
        private Node left, right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="inputedData">inputed data</param>
        public Node(int inputedData)
        {
            this.data = inputedData;
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public int Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (value == this.data)
                {
                    return;
                }
                else
                {
                    this.data = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the right child node
        /// </summary>
        public Node Right
        {
            get
            {
                return this.right;
            }

            set
            {
                if (this.right == value)
                {
                    return;
                }
                else
                {
                    this.right = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the left child node
        /// </summary>
        public Node Left
        {
            get
            {
                return this.left;
            }

            set
            {
                if (this.left == value)
                {
                    return;
                }
                else
                {
                    this.left = value;
                }
            }
        }
    }
}
// <copyright file="BasicNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System.Diagnostics.CodeAnalysis;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]

    /// <summary>
    /// Basic node class
    /// </summary>
    internal abstract class BasicNode
    {
        /// <summary>
        /// Name:name
        /// Description: a string to be setted in other classes that inherit from base node
        /// </summary>
        protected string name;

        /// <summary>
        /// Name:operatorValue
        /// Description: a double to be setted in other classes that inherit from base node
        /// </summary>
        protected double operatorValue;

        /// <summary>
        /// Gets or sets functions for name
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }
                else
                {
                    this.name = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets funtion for operatorValue
        /// </summary>
        public double OperatorValue
        {
            get
            {
                return this.operatorValue;
            }

            set
            {
                if (this.operatorValue == value)
                {
                    return;
                }
                else
                {
                    this.operatorValue = value;
                }
            }
        }

    }
}
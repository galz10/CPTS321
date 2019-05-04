// <copyright file="VariableNode.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    /// <summary>
    /// a variable node class that inherits from basic node
    /// </summary>
    internal class VariableNode : BasicNode
    {
        /// <summary>
        /// Name:VariableNode
        /// Description:Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="varName">variable name</param>
        public VariableNode(string varName)
        {
            this.name = varName;
        }
    }
}

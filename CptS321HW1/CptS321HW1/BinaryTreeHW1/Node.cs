// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinaryTreeHW1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Name:Node
    /// Description: This class holds functions of the node
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class Node
    {
        /// <summary>
        /// Name:leftLeaf
        /// Description:left leaf of a node
        /// </summary>
        private Node leftLeaf;

        /// <summary>
        /// Name:rightLeaf
        /// Description: right leaf of a node
        /// </summary>
        private Node rightLeaf;

        /// <summary>
        /// Name:data
        /// Description: data of a node
        /// </summary>
        private int data;

        /// <summary>
        /// Name:GetData
        /// Description: gets the data in a node
        /// </summary>
        /// <returns> returns node data </returns>
        public int GetData()
        {
            return this.data;
        }

        /// <summary>
        /// Name:GetLeftLeaf
        /// Description:Returns the left leaf node
        /// </summary>
        /// <returns> Node of the left leaf </returns>
        public Node GetLeftLeaf()
        {
            return this.leftLeaf;
        }

        /// <summary>
        /// Name:GetRightLeaf
        /// Description:Returns the right leaf node
        /// </summary>
        /// <returns> Node of the left leaf </returns>
        public Node GetRightLeaf()
        {
            return this.rightLeaf;
        }

        /// <summary>
        /// Name:SetRightLeaf
        /// Description:Sets the right leaf to the newNode
        /// </summary>
        /// <param name="newNode"> is an inputed root of a node </param>
        public void SetRightLeaf(Node newNode)
        {
            this.rightLeaf = newNode;
        }

        /// <summary>
        /// Name:SetLeftLeaf
        /// Description:Sets the left leaf to newNode
        /// </summary>
        /// <param name="newNode"> is an inputed root of a node </param>
        public void SetLeftLeaf(Node newNode)
        {
            this.leftLeaf = newNode;
        }

        /// <summary>
        /// Name:SetData
        /// Description:Sets the data of a node to newData
        /// </summary>
        /// <param name="newData"> is an inputed Data</param>
        public void SetData(int newData)
        {
            this.data = newData;
        }
    }
}

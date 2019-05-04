// <copyright file="BinaryTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinaryTreeHW1
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Name:BinaryTree
    /// Description:This class holds all the function for the creation,printing, and getting the levels of the binary tree
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Error isn't correct")]
    public class BinaryTree
    {
        /// <summary>
        /// Name: nodeCount
        /// Description: Node count, counts the amount of nodes
        /// </summary>
        private static int nodeCount = 1;

        /// <summary>
        /// Name: Root
        /// Description: the root of a node
        /// </summary>
        private static Node root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree"/> class.
        /// </summary>
        public BinaryTree()
        {
            root = null;
        }

        /// <summary>
        /// Name:ReturnRoot
        /// Description:returns the root
        /// </summary>
        /// <returns> returns the root </returns>
        public static Node ReturnRoot()
        {
            return root;
        }

        /// <summary>
        /// Name:GetNodeCount
        /// Description:returns node count
        /// </summary>
        /// <returns> Node Count </returns>
        public static int GetNodeCount()
        {
            return nodeCount;
        }

        /// <summary>
        /// Name:InsertData
        /// Description:This takes an inputed data and inserts it into a node to build a Binary Tree
        /// </summary>
        /// <param name="inData"> typed data that gets put into a node, to build the Binary Tree </param>
        /// <returns> returns true or false so its easy to test</returns>
        public static bool InsertData(int inData)
        {
            Node newNode = new Node();
            newNode.SetData(inData);
            if (root == null)
            {
                root = newNode;
                return true;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (inData < current.GetData())
                    {
                        current = current.GetLeftLeaf();
                        if (current == null)
                        {
                            nodeCount++;
                            parent.SetLeftLeaf(newNode);
                            return false;
                        }
                    }
                    else
                    {
                        current = current.GetRightLeaf();
                        if (current == null)
                        {
                            nodeCount++;
                            parent.SetRightLeaf(newNode);
                            return false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Name:PrintBT()
        /// Description:Traverses Binary Tree and prints it out in order
        /// </summary>
        /// <param name="tempRoot"> This is accesses the root of the node so it can traverse the the Binary Tree </param>
        /// <param name="count"> Makes so the function prints out tree contents correctly </param>
        /// <returns> Returns a bool for testing </returns>
        public static bool PrintBT(Node tempRoot, int count)
        {
            if (count == 0)
            {
                Console.Write("Tree Contents: ");
            }

            if (tempRoot != null)
            {
                PrintBT(tempRoot.GetLeftLeaf(), 1);
                Console.Write(tempRoot.GetData() + " ");
                PrintBT(tempRoot.GetRightLeaf(), 1);
            }

            return true;
        }

        /// <summary>
        /// Name:ComptuteMinLevel
        /// Description:Computes the minimum level with a given node
        /// </summary>
        /// <param name="inRoot"> This takes in the tempNode of a node so it can compute the level </param>
        /// <returns> Minimum level from a given node </returns>
        public static int ComputeMinLevel(Node inRoot)
        {
            if (inRoot == null)
            {
                return 0;
            }

            if (inRoot.GetRightLeaf() == null && inRoot.GetLeftLeaf() == null)
            {
                return 1;
            }

            if (inRoot.GetLeftLeaf() == null)
            {
                return ComputeMinLevel(inRoot.GetRightLeaf()) + 1;
            }
            if (inRoot.GetRightLeaf() == null)
            {
                return ComputeMinLevel(inRoot.GetLeftLeaf()) + 1;
            }

            return Math.Min(ComputeMinLevel(inRoot.GetLeftLeaf()), ComputeMinLevel(inRoot.GetRightLeaf())) + 1;
        }

        /// <summary>
        /// Name: ComputeLevel
        /// Description: This function computes the level of the binary tree
        /// </summary>
        /// <param name="inRoot">This takes in the tempNode of a node so it can compute the level</param>
        /// <returns> return the level of binary tree </returns>
        public static int ComputeLevel(Node inRoot)
        {
            if (inRoot == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(ComputeLevel(inRoot.GetLeftLeaf()), ComputeLevel(inRoot.GetRightLeaf()));
            }
        }
    }
}

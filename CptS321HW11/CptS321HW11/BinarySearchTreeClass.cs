// <copyright file="BinarySearchTreeClass.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW11
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Name:Binary Tree class
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// the root
        /// </summary>
        private Node root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree"/> class.
        /// </summary>
        public BinaryTree()
        {
            this.root = null;
        }

        /// <summary>
        /// Gets or sets the root variable
        /// </summary>
        public Node Root
        {
            get
            {
                return this.root;
            }

            set
            {
                if (value == this.root)
                {
                    return;
                }
                else
                {
                    this.root = value;
                }
            }
        }

        /// <summary>
        /// Name:InsertData
        /// Description:inserts the data into the binary tree
        /// </summary>
        /// <param name="data">inputed data</param>
        public void InsertData(int data)
        {
            Node newNode = new Node(data);
            Node currentNode = this.root;
            Node parentNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data != data)
                {
                    if (currentNode.Data < data)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    return;
                }
            }

            if (parentNode != null)
            {
                if (parentNode.Data < data)
                {
                    parentNode.Right = newNode;
                }
                else
                {
                    parentNode.Left = newNode;
                }
            }
            else
            {
                this.root = newNode;
            }
        }
        
        /// <summary>
        /// Name:NormalInOrderTraversal
        /// Description:normal in order traversal
        /// </summary>
        /// <param name="rootNode">the root node</param>
        public void NormalInOrderTraversal(Node rootNode)
        {
            if (rootNode != null)
            {
                this.NormalInOrderTraversal(rootNode.Left);
                Console.Write(rootNode.Data + " ");
                this.NormalInOrderTraversal(rootNode.Right);
            }
        }
        
        /// <summary>
        /// Name:StackNoRecursionTraversal
        /// Description:traverses the binary tree without recursion
        /// </summary>
        /// <param name="rootNode">the root node</param>
        public void StackNoRecursionTraversal(Node rootNode)
        {
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = new Node();
            currentNode = rootNode;
            bool value = false;

            while (value != true)
            {
                if (currentNode == null)
                {
                    if (stack.Count == 0)
                    {
                        value = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        Console.Write(currentNode.Data + " ");
                        currentNode = currentNode.Right;
                    }
                }
                else
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
            }
        }

        /// <summary>
        /// Name:NoStackAndRecursionTraversal
        /// Description:traverses the binary tree without a stack and recursion
        /// </summary>
        /// <param name="rootNode">the root node</param>
        public void NoStackAndRecursionTraversal(Node rootNode)
        {
            Node currentNode = new Node(), previousNode = new Node();
            currentNode = rootNode;

            while (currentNode != null)
            {
                if (currentNode.Left != null)
                {
                    previousNode = currentNode.Left;

                    while (previousNode.Right != null && previousNode.Right != currentNode)
                    {
                        previousNode = previousNode.Right;
                    }

                    if (previousNode.Right != null)
                    {
                        previousNode.Right = null;
                        Console.Write(currentNode.Data + " ");
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        previousNode.Right = currentNode;
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    Console.Write(currentNode.Data + " ");
                    currentNode = currentNode.Right;
                }
            }
        }
    }
}
// <copyright file="Program.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW11
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// prgram class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// this is main
        /// </summary>
        /// <param name="args">inputed argument</param>
        public static void Main(string[] args)
        {
            string input = "0";
            while (input != "2")
            {
                BinaryTree binaryTree = new BinaryTree();
                Random rand = new Random();
                int node = rand.Next(20, 30);

                for (int i = 0; i < node; i++)
                {
                    binaryTree.InsertData(rand.Next(0, 101));
                }

                Console.WriteLine("Traversal of the tree using recursion");
                binaryTree.NormalInOrderTraversal(binaryTree.Root);
                Console.WriteLine();

                Console.WriteLine("Traversal of the tree using a stack but NO recursion");
                binaryTree.StackNoRecursionTraversal(binaryTree.Root);
                Console.WriteLine();

                Console.WriteLine("Traversal of the tree using NO stack and NO recursion");
                binaryTree.NoStackAndRecursionTraversal(binaryTree.Root);
                Console.WriteLine();

                Console.WriteLine("Do you want to run this again? 1) Yes 2) No");
                input = Console.ReadLine();
            }
        }
    }
}
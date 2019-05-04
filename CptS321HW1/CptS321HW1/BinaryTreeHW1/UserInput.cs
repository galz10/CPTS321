// <copyright file="UserInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinaryTreeHW1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Name:
    /// Description: This class takes the typed values and loads it into a Binary Tree
    /// Functions: GetInputedNumbers()
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Error Is Not Correct")]
    public class UserInput
    {
        /// <summary>
        /// Name:GetInputedNumber
        /// Description:this function gets typed data and puts it into the binary tree
        /// </summary>
        public void GetInputedNumbers()
        {
            Console.WriteLine("Enter a collection of numbers in the range [0,100], separated by spaces");
            string input = Console.ReadLine();
            string[] split = input.Split(' ');
            string[] distinctString = split.Distinct().ToArray();
            for (int i = 0; i < distinctString.Length; ++i)
            {
                int convSplit;
                bool checkParsed = int.TryParse(distinctString[i], out convSplit);

                if (convSplit < 0 || convSplit > 100)
                {
                    Console.WriteLine("ERROR!! " + convSplit + " Is Out of Bounds");
                }
                else
                {
                    BinaryTree.InsertData(convSplit);
                }
            }

            // Console.WriteLine("[{0}]", string.Join(",", split));
            BinaryTree.PrintBT(BinaryTree.ReturnRoot(), 0);
            Console.WriteLine(" ");
            Console.WriteLine("Tree Satistics:");
            Console.WriteLine("     Node Count: " + BinaryTree.GetNodeCount());
            Console.WriteLine("     Level: " + BinaryTree.ComputeLevel(BinaryTree.ReturnRoot()));
            Console.WriteLine("     Minimum number of levels that a tree with " + BinaryTree.GetNodeCount() + " nodes could have = " + BinaryTree.ComputeMinLevel(BinaryTree.ReturnRoot()));
        }
    }
}

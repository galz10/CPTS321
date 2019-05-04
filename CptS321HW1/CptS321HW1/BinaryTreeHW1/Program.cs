// <copyright file="Program.cs" company="PlaceholderCompany">
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
    /// Name: Program
    /// Description:Sets up main for the program
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Reviewed.")]
    internal class Program
    {
        /// <summary>
        /// Name:Main
        /// Description:Is the main of the whole program
        /// </summary>
        /// <param name="args"> set up main</param>
        private static void Main(string[] args)
        {
            UserInput u = new UserInput();
            u.GetInputedNumbers();
        }
    }
}
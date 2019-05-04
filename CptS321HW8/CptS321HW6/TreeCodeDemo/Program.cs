// <copyright file="Program.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace CPTS321
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:AccessModifierMustBeDeclared", Justification = "Reviewed.")]
    
    /// <summary>
    /// program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// main for the program
        /// </summary>
        /// <param name="args">string arg</param>
        public static void Main(string[] args)
        {
            string userInput = "0";

            ExpressionTree tree = new ExpressionTree("5+A2+7");

            while (userInput != "4")
            {
                StringBuilder menu = new StringBuilder();
                menu.AppendLine("Menu (current expression = \"" + tree.Expression + "\")");
                menu.AppendLine("   1 = Enter a new expression");
                menu.AppendLine("   2 = Set a variable value");
                menu.AppendLine("   3 = Evaluate Tree");
                menu.AppendLine("   4 = Quit");

                Console.WriteLine(menu);

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter new expression: ");
                        string expression = Console.ReadLine();
                        tree = new ExpressionTree(expression);
                        break;
                    case "2":
                        Console.Write("Enter variable name: ");
                        string varName = Console.ReadLine();
                        Console.Write("Enter variable value: ");
                        string varValue = Console.ReadLine();
                        double num;

                        while (!double.TryParse(varValue, out num))
                        {
                            Console.Write("Enter variable value: ");
                            varValue = Console.ReadLine();
                        }

                        tree.SetVariable(varName, num);
                        break;
                    case "3":
                        Console.WriteLine(tree.Evaluate());
                        break;
                }
            }
        }
    }
}
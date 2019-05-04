// <copyright file="Fibonacci.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW3
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Numerics;
    using System.Text;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// initializes Fibonacci class
    /// </summary>
    public class Fibonacci : TextReader
    {
        /// <summary>
        /// Name:
        /// Description:
        /// </summary>
        private int num = 0;

        /// <summary>
        /// Name:
        /// Description:
        /// </summary>
        private int curLine = 0;

        /// <summary>
        /// Name:Fibonacci
        /// Initializes a new instance of the <see cref="Fibonacci"/> class.
        /// </summary>
        /// <param name="number">initializes Fibonacci with the number inputed</param>
        public Fibonacci(int number)
        {
            this.num = number;
            this.curLine = 1;
        }

        /// <summary>
        /// Name:FindFib
        /// Description:find the Fibonacci of a biginteger
        /// </summary>
        /// <param name="numb">the big integer number that you want to find the Fibonacci</param>
        /// <returns>returns first number</returns>
        public static BigInteger FindFib(BigInteger numb)
        {
            BigInteger first = 0, second = 1, i = 0, tempNumb = 0;

            while (i++ < numb)
            {
                tempNumb = first;
                first = second;
                second = tempNumb + second;
            }

            return first;
        }

        /// <summary>
        /// Name:ReadToEnd
        /// Description:overides the readtoend function so it can work with finding Fibonacci
        /// </summary>
        /// <returns>returns Fibonacci </returns>
        public override string ReadToEnd()
        {
            StringBuilder fibString = new StringBuilder();
            for (int i = 1; i++ < this.num;)
            {
                if (this.curLine <= this.num)
                {
                    fibString.Append("(" + this.curLine.ToString() + ")  " + FindFib(this.curLine - 1).ToString() + Environment.NewLine);
                }
                else
                {
                    return null;
                }

                this.curLine++;
            }

            return fibString.ToString();
        }
    }
}

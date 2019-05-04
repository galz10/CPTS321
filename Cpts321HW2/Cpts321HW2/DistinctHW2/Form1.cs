// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace DistinctHW2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Name:Form1
    /// Description: sets up the class for the form1 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Name: Form1
        /// Initializes a new instance of the <see cref="Form1"/> class 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            var rand = new Random();
            var randlist = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                randlist.Add(rand.Next(20000));
            }

            StringBuilder sb = new StringBuilder(string.Empty);
            sb.AppendLine("1. HashSet Method: " + HashSetMethod(randlist).ToString() + " distinct items.");
            sb.AppendLine("2. O(1) Storage Method: " + StorageMethod(randlist).ToString() + " distinct items.");
            sb.AppendLine("3. Sorted Method: " + SortedMethod(randlist).ToString() + " distinct items.");
            textBox1.Text = sb.ToString();
        }

        /// <summary>
        /// Name:HashSetMethod
        /// Description:This method uses hashset to get the distinct numbers in the list
        /// </summary>
        /// <param name="numList">inputed list of numbers</param>
        /// <returns>count of distinct numbers</returns>
        public static int HashSetMethod(List<int> numList)
        {
            var set = new HashSet<int>(numList);
            return set.Count();
        }

        /// <summary>
        /// Name:storageMethod uses a O(1) complexity and gets the distinct count of numbers without changing the numList
        /// Description:This method 
        /// </summary>
        /// <param name="numList">inputed list of numbers</param>
        /// <returns>count of distinct numbers</returns>
        public static int StorageMethod(List<int> numList)
        {
            int count = 0;
            for (int x = 0; x < numList.Count; x++)
            {
                int decider = 0;
                for (int y = x + 1; y < numList.Count; y++)
                {
                    if (numList[x] == numList[y])
                    {
                        decider = -1;
                    }
                }

                if (decider != -1)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Name:SortedMethod
        /// Description:this method sorts the numList and then counts the distinct numbers
        /// </summary>
        /// <param name="numList">Inputed list of numbers</param>
        /// <returns>count of distinct numbers</returns>
        public static int SortedMethod(List<int> numList)
        {
            numList.Sort();
            int distinctCount = 1;
            for (int x = 0, y = 1; x < numList.Count - 1; x++, y++)
            {
                if (numList[x] != numList[y])
                {
                    distinctCount++;
                }
            }

            return distinctCount;
        }

        /// <summary>
        /// Name: Form1_load
        /// Description:this function lets the window load
        /// </summary>
        /// <param name="sender">Object of form1_load</param>
        /// <param name="e">Event of form1_load </param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}

// <copyright file="FibonacciTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW3.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Gal_Zahavi_11573719_CptS321HW3;
    using NUnit.Framework;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// sets up a class for testing finonacci
    /// </summary>
    [TestFixture]
    public class FibonacciTests
    {
        /// <summary>
        /// test Fibonacci
        /// </summary>
        [Test]
        public void FibonacciTest()
        {
            Assert.IsNotEmpty(Fibonacci.FindFib(455).ToString());
        }

        /// <summary>
        /// tests the findfib function
        /// </summary>
        [Test]
        public void FindFibTest()
        {
            Assert.IsNotEmpty(Fibonacci.FindFib(10).ToString());
        }
    }
}
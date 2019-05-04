// <copyright file="Form1Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW3.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Sets up the class for tests to be held
    /// </summary>
    [TestFixture]
    public class Form1Tests
    {
        /// <summary>
        /// sets up a function for tests to be called
        /// </summary>
        [Test]
        public void Form1Test()
        {
            Assert.IsNotEmpty(Fibonacci.FindFib(100).ToString());
        }
    }
}
// <copyright file="SpreadSheetTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// class for spreadsheet test
    /// </summary>
    [TestFixture]
    public class SpreadsheetTests
    {
        /// <summary>
        /// test for spreadsheet test
        /// </summary>
        [Test]
        public void SpreadsheetTest()
        {
            Spreadsheet sheet = new Spreadsheet(26,50);
           
        }

        /// <summary>
        /// test for property changed test
        /// </summary>
        [Test]
        public void PropertyChangedTest()
        {
            Assert.Fail();
        }
    }
}
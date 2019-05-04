// <copyright file="Form1Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace DistinctHW2.Tests
{
    using System.Collections.Generic;
    using DistinctHW2;
    using NUnit.Framework;

    /// <summary>
    /// Name:Form1Tests
    /// Description: sets up a place to put the test methods
    /// </summary>
    [TestFixture]
    public class Form1Tests
    {
        /// <summary>
        /// Name:Form1Test
        /// Description:
        /// </summary>
        [Test]
        public void Form1Test()
        {
        }

        /// <summary>
        /// Name:hashSetMethodTest
        /// Description: This tests the hashSetMethod 
        /// </summary>
        [Test]
        public void HashSetMethodTest()
        {
            List<int> hashTestList = new List<int>();
            hashTestList.Add(1);
            hashTestList.Add(3);
            hashTestList.Add(1);
            hashTestList.Add(2);
            hashTestList.Add(4);
            Assert.AreEqual(Form1.HashSetMethod(hashTestList), 4);
        }

        /// <summary>
        /// Name:storageMethodTest
        /// Description:This tests the storageMethodTest
        /// </summary>
        [Test]
        public void StorageMethodTest()
        {
            List<int> storageTestList = new List<int>();
            storageTestList.Add(1);
            storageTestList.Add(3);
            storageTestList.Add(1);
            storageTestList.Add(2);
            storageTestList.Add(4);

            Assert.AreEqual(Form1.StorageMethod(storageTestList), 4);
        }

        /// <summary>
        /// Name:sortedMethodTest
        /// Description:This tests the sortedMethod
        /// </summary>
        [Test]
        public void SortedMethodTest()
        {
            List<int> sortedTestList = new List<int>();
            sortedTestList.Add(1);
            sortedTestList.Add(3);
            sortedTestList.Add(1);
            sortedTestList.Add(2);
            sortedTestList.Add(4);

            Assert.AreEqual(Form1.SortedMethod(sortedTestList), 4);
        }
    }
}
// <copyright file="BinaryTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinaryTreeHW1.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Description: class for the test function
    /// </summary>
    [TestFixture]
    public class BinaryTreeTests
    {
        /// <summary>
        /// Name:BinaryTreeTest
        /// Description:There's nothing to test here
        /// </summary>
        [Test]
        public void BinaryTreeTest()
        {
        }

        /// <summary>
        /// Name:ReturnRootTest
        /// Description:Checks if return root doesn't return null
        /// </summary>
        [Test]
        public void ReturnRootTest()
        {
            Assert.IsNotNull(BinaryTree.ReturnRoot());
        }

        /// <summary>
        /// Name:GetNodeCountTest
        /// Description:Checks if the node count is correct
        /// </summary>
        [Test]
        public void GetNodeCountTest()
        {
            Assert.AreEqual(BinaryTree.GetNodeCount(), 1);
        }

        /// <summary>
        /// Name:InsertDataTest
        /// Description:Checks if the insert function works correctly
        /// </summary>
        [Test]
        public void InsertDataTest()
        {
            Assert.IsTrue(BinaryTree.InsertData(43));
        }

        /// <summary>
        /// Name:PrintBTTest
        /// Description:Checks if the print function is working
        /// </summary>
        [Test]
        public void PrintBTTest()
        {
            Assert.IsTrue(BinaryTree.PrintBT(BinaryTree.ReturnRoot(), BinaryTree.GetNodeCount()));
        }

        /// <summary>
        /// Name:ComputeMinLevelTest
        /// Description:Test the compute minimum level function
        /// </summary>
        [Test]
        public void ComputeMinLevelTest()
        {
            Assert.AreEqual(BinaryTree.ComputeMinLevel(BinaryTree.ReturnRoot()), 0);
        }

        /// <summary>
        /// Name:ComputeLevelTest
        /// Description:Tests the compute level function
        /// </summary>
        [Test]
        public void ComputeLevelTest()
        {
            Assert.AreEqual(BinaryTree.ComputeLevel(BinaryTree.ReturnRoot()), 0);
        }
    }
}
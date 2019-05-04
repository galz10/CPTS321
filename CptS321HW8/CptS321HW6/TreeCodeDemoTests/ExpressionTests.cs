// <copyright file="ExpressionTests.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>

namespace CPTS321
{
    using NUnit.Framework;

    /// <summary>
    /// test class 
    /// </summary>
    [TestFixture]
    public class ExpressionTests
    {
        /// <summary>
        /// test case 1
        /// </summary>
        private CPTS321.ExpressionTree underTest1 = new CPTS321.ExpressionTree("3+5+4");

        /// <summary>
        /// test case 2
        /// </summary>
        private CPTS321.ExpressionTree underTest2 = new CPTS321.ExpressionTree("3-2+1");

        /// <summary>
        /// test case 3
        /// </summary>
        private CPTS321.ExpressionTree underTest3 = new CPTS321.ExpressionTree("10/5");

        /// <summary>
        /// test case 4
        /// </summary>
        private CPTS321.ExpressionTree underTest4 = new CPTS321.ExpressionTree("10/2*5");

        /// <summary>
        /// test case 5
        /// </summary>
        private CPTS321.ExpressionTree underTest5 = new CPTS321.ExpressionTree("2+3-4+5");

        /// <summary>
        /// test case 6
        /// </summary>
        private CPTS321.ExpressionTree underTest6 = new CPTS321.ExpressionTree("((2+3)*(5+2))");

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest1()
        {
            Assert.AreEqual(12, this.underTest1.Evaluate());
            Assert.AreEqual("3+5+4", this.underTest1.Expression);
            Assert.IsNotNull(this.underTest1);
        }

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest2()
        {
            Assert.AreEqual(2, this.underTest2.Evaluate());
            Assert.AreEqual("3-2+1", this.underTest2.Expression);
            Assert.IsNotNull(this.underTest2);
        }

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest3()
        {
            Assert.AreEqual(2, this.underTest3.Evaluate());
            Assert.AreEqual("10/5", this.underTest3.Expression);
            Assert.IsNotNull(this.underTest3);
        }

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest4()
        {
            Assert.AreEqual(25, this.underTest4.Evaluate());
            Assert.AreEqual("10/2*5", this.underTest4.Expression);
            Assert.IsNotNull(this.underTest4);
        }

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest5()
        {
            Assert.AreEqual(6, this.underTest5.Evaluate());
            Assert.AreEqual("2+3-4+5", this.underTest5.Expression);
            Assert.IsNotNull(this.underTest5);
        }

        /// <summary>
        /// test function
        /// </summary>
        [Test]
        public void ExpressionTest5()
        {
            Assert.AreEqual(42, this.underTest5.Evaluate());
            Assert.AreEqual("((2+3)*(5+2))", this.underTest5.Expression);
            Assert.IsNotNull(this.underTest5);
        }
    }
}

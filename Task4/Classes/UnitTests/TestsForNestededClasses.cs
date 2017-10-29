using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTests
{
    /// <summary>
    /// Tests for NestededClasses class
    /// </summary>
    [TestClass]
    public class TestsForNestededClasses
    {
        /// <summary>
        /// Tests GetsumMetod to add two values
        /// by creating new thread
        /// </summary>
        [TestMethod]
        public void GetSum_100Plus100_200Expected()
        {
            //arrange
            NestededClasses cl = new NestededClasses();
            //act
            int value = cl.GetSum(100, 100);
            //assert
            Assert.AreEqual(value, 200);
        }
    }
}

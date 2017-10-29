using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTests
{
    /// <summary>
    /// Tests for Partial class
    /// </summary>
    [TestClass]
    public class TestsForPartial
    {
        /// <summary>
        /// Tests GetArraySum method
        /// </summary>
        [TestMethod]
        public void GetArraySum_5digitsArray_10Expected()
        {
            //arrange
            Partial partial = new Partial();
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            //act 
            int value = partial.GetArraySum(array);
            //assert
            Assert.AreEqual(value, 10);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTests
{
    /// <summary>
    /// Tests for StaticExtenssions class
    /// </summary>
    [TestClass]
    public class TestsForStaticExtenssions
    {
        /// <summary>
        /// Tests bool value parsing
        /// </summary>
        [TestMethod]
        public void ToBool_ToBoolParse1_TrueExpected()
        {
            //arrange
            int value = 1;
            //act
            bool MyBool = value.ToBool();
            //assert
            Assert.AreEqual(MyBool, true);
        }

        /// <summary>
        /// Tests bool value parsing
        /// </summary>
        [TestMethod]
        public void ToBool_ToBoolParse0_FalseExpected()
        {
            //arrange
            int value =0;
            //act
            bool MyBool = value.ToBool();
            //assert
            Assert.AreEqual(MyBool, false);
        }
    }
}

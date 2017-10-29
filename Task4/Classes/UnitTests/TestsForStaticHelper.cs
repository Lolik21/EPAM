using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTests
{
    /// <summary>
    /// Include tests for Static Helper class
    /// </summary>
    [TestClass]
    public class TestsForStaticHelper
    {
        /// <summary>
        /// Simple addition test
        /// </summary>
        [TestMethod]
        public void Add_1Plus5_6Rezult()
        {
            //arrange
            int value;
            //act
            value = StaticHelper.Add(1, 5);
            //assert
            Assert.AreEqual(value, 6);

        }

        /// <summary>
        /// Simple adddition test
        /// </summary>
        [TestMethod]
        public void Add_5Plus5_10Rezult()
        {
            //arrange
            int value;
            //act
            value = StaticHelper.Add(5, 5);
            //assert
            Assert.AreEqual(value, 10);
        }

        /// <summary>
        /// Simple multiplication test
        /// </summary>
        [TestMethod]
        public void Multiply_5Multiply5_25Rezult()
        {
            //arrange
            int value;
            //act
            value = StaticHelper.Multiply(5, 5);
            //assert
            Assert.AreEqual(value, 25);
        }

        /// <summary>
        /// Simple multiplication test
        /// </summary>
        [TestMethod]
        public void Multiply_5Multiply10_50Rezult()
        {
            //arrange
            int value;
            //act
            value = StaticHelper.Multiply(5, 10);
            //assert
            Assert.AreEqual(value, 50);
        }

        /// <summary>
        /// Creats 2 objects and compate them with the help
        /// of StaticHelper class
        /// </summary>
        [TestMethod]
        public void Copy_SimpleClass_Class2CopyClass1_EqualFields()
        {
            //arrange
            SimpleClass Class1 = new SimpleClass();
            Class1.Field1 = "hello";
            Class1.Field2 = "hello22";
            SimpleClass Class2 = new SimpleClass();
            //act
            StaticHelper.Copy_SimpleClass(Class2, Class1);
            //assert
            Assert.AreEqual(Class2.Field1, Class1.Field1);
            Assert.AreEqual(Class2.Field2, Class1.Field2);
        }

    }
}

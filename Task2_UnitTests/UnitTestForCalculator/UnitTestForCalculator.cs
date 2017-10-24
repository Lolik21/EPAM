using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_UnitTests;

namespace UnitTestForCalculator
{
    /// <summary>
    /// Contains test for class Calculator
    /// </summary>
    [TestClass]
    public class UnitTestForCalculator
    {
        /// <summary>
        /// Tests two numbers addition
        /// </summary>
        [TestMethod]
        public void Add_333Plus777_1110Returned()
        {
            // arrange
           
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Add(333, 777);
            // assert
            Assert.AreEqual(rezult, 1110);
        }

        /// <summary>
        /// Tests two numbers addition
        /// </summary>
        [TestMethod]
        public void Add_666Plus777_1443Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Add(666, 777);
            // assert
            Assert.AreEqual(rezult, 1443);
        }

        /// <summary>
        /// Tests OverflowExeption to be created
        /// when size of the rezult variable is less
        /// then the rezult of addition
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_MaxIntPlusMaxInt_OverflowExceptionExpected()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Add(int.MaxValue, int.MaxValue);
            // assert is handled by the ExpectedException
        }

        /// <summary>
        /// Tests two numbers division
        /// </summary>
        [TestMethod]
        public void Divide_777Divide111_7Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            double rezult = calc.Divide(777, 111);
            // assert
            Assert.AreEqual(rezult, 7);
        }

        /// <summary>
        /// Tests two numbers division
        /// </summary>
        [TestMethod]
        public void Divide_777Divide7_111Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            double rezult = calc.Divide(777, 7);
            // assert
            Assert.AreEqual(rezult, 111);
        }

        /// <summary>
        /// Tests OverflowExeption to be created
        /// when value is divide by zero
        /// </summary
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_1Divide0_DivideByZeroExceptionExpected()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            double rezult = calc.Divide(1, 0);
            // assert is handled by the ExpectedException
        }

        /// <summary>
        /// Tests two numbers substraction
        /// </summary>
        [TestMethod]
        public void Subtract_777Minus333_444Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Subtract(777, 333);
            // assert
            Assert.AreEqual(rezult, 444);
        }

        /// <summary>
        /// Tests two numbers substraction
        /// </summary>
        [TestMethod]
        public void Subtract_777Minus666_111Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Subtract(777, 666);
            // assert
            Assert.AreEqual(rezult, 111);
        }

        /// <summary>
        /// Tests OverflowExeption to be created
        /// when size of the rezult variable is less
        /// then the rezult of substraction
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Subtract_MinIntMinusMaxInt_OverflowExceptionExpected()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Subtract(int.MinValue, int.MaxValue);
            // assert is handled by the ExpectedException
        }

        /// <summary>
        /// Tests two numbers multiplication
        /// </summary>
        [TestMethod]
        public void Multiply_333Times777_258741Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Multiply(333, 777);
            // assert
            Assert.AreEqual(rezult, 258741);
        }

        /// <summary>
        /// Tests two numbers multiplication
        /// </summary>
        [TestMethod]
        public void Multiply_6Times7_42Returned()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Multiply(6, 7);
            // assert
            Assert.AreEqual(rezult, 42);
        }

        /// <summary>
        /// Tests OverflowExeption to be created
        /// when size of the rezult variable is less
        /// then the rezult of multiplication
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Multiply_MaxIntTimesMaxInt_OverflowExceptionExpected()
        {
            // arrange
            ISimpleCalculator calc = new Calculator();
            // act 
            int rezult = calc.Multiply(int.MaxValue, int.MaxValue);
            // assert is handled by the ExpectedException
        }
    }
}

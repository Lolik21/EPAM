using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_UnitTests
{
    /// <summary>
    /// Performs simple mathematical operations (+,-,*,/)
    /// </summary>
    public class Calculator : ISimpleCalculator
    {
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="Value1">First value for the addition</param>
        /// <param name="Value2">Second value for the addition</param>
        /// <returns>Result of the addition</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the addition
        /// is more then rezult variable size
        /// </exception>
        public int Add(int Value1, int Value2)
        {
            return checked(Value1 + Value2);
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="Value1">First value for the division</param>
        /// <param name="Value2">Second value for the division</param>
        /// <returns>Result of the division</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="Value2"/> is 0
        /// </exception>
        public double Divide(int Value1, int Value2)
        {
            return Value1 / Value2;
        }

        /// <summary>
        /// Multiplys two numbers
        /// </summary>
        /// <param name="Value1">First value for the multiplication</param>
        /// <param name="Value2">Second value for the multiplication</param>
        /// <returns>Result of the multiplication</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the multiplication
        /// is more then rezult variable size
        /// </exception>
        public int Multiply(int Value1, int Value2)
        {
            return checked(Value1 * Value2);
        }

        /// <summary>
        /// Subtracts two numbers
        /// </summary>
        /// <param name="Value1">First value for the subtraction</param>
        /// <param name="Value2">Second value for the subtraction</param>
        /// <returns>Result of the subtraction</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the subtraction
        /// is more then rezult variable size
        /// </exception>
        public int Subtract(int Value1, int Value2)
        {
            return checked(Value1 - Value2);
        }
    }
}

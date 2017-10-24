using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_UnitTests
{
    /// <summary>
    /// Defines methods of simple calculator
    /// </summary>
    interface ISimpleCalculator
    {
        int Add(int Value1, int Value2);
        int Subtract(int Value1, int Value2);
        int Multiply(int Value1, int Value2);
        double Divide(int Value1, int Value2);
    }
}

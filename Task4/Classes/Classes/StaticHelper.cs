using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Classes
{

    /// <summary>
    /// Class to show how static helpers work
    /// </summary>
    public static class StaticHelper
    {
        /// <summary>
        /// Adds value1 and value2
        /// </summary>
        /// <param name="value1">First value to add</param>
        /// <param name="value2">Second value to add</param>
        /// <returns>Sum of value1 and value2</returns>
        public static int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        /// <summary>
        /// Multiply value1 and value2
        /// </summary>
        /// <param name="value1">First value to multiply</param>
        /// <param name="value2">Second value to multiply</param>
        /// <returns></returns>
        public static int Multiply(int value1, int value2)
        {
            return value2 * value1;
        }

        /// <summary>
        /// Copies class2 fields to class1 fields
        /// </summary>
        /// <param name="class1">Class to copy in</param>
        /// <param name="class2">Class to copy from</param>
        public static void Copy_SimpleClass(SimpleClass class1, SimpleClass class2)
        {
            class1.Field1 = class2.Field1;
            class1.Field2 = class2.Field2;
        }
    }
}
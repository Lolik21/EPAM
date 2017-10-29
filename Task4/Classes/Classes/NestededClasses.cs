using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Classes
{
    /// <summary>
    /// Class for shoing how Nested classes work
    /// </summary>
    public class NestededClasses
    {
        /// <summary>
        /// Nested test class
        /// </summary>
        class Nested1
        {
            public int nestedValue1;
            public int nestedValue2;
            public int sum;
        }

        /// <summary>
        /// Gets sum of value1 and value2
        /// by creating new thread ;)
        /// </summary>
        /// <param name="value1">First value to add</param>
        /// <param name="value2">Second value to add</param>
        /// <returns>Sum of value1 and value2</returns>
        public int GetSum(int value1, int value2)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Sum));
            Nested1 nested1 = new Nested1
            {
                nestedValue1 = value1,
                nestedValue2 = value2
            };
            thread.Start(nested1);
            Thread.Sleep(1000);
            return nested1.sum;
        }

        private void Sum(object obj)
        {
            Nested1 nested = obj as Nested1;
            nested.sum = nested.nestedValue1 + nested.nestedValue2;
        }
    }

}

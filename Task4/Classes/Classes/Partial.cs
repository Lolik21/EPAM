using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Class to show how Partial classes work
    /// </summary>
    public partial class Partial
    {
        /// <summary>
        /// Method gets array sum
        /// </summary>
        /// <param name="array">Array to get sum</param>
        /// <returns>Sum of the array elements</returns>
        public int GetArraySum(int[] array)
        {
            int Sum = 0;
            for (int i = 0; i < array.Length; i++)
                Sum = Sum + array[i];
            ShowRezult(Sum);
            return Sum;
        }
    }

    public partial class Partial
    {
        /// <summary>
        /// Standalone method for showing rezult of 
        /// method GetArraySum
        /// </summary>
        /// <param name="Sum">Rezult to show</param>
        public void ShowRezult(int Sum)
        {
            //Console.WriteLine(Sum);
        }
    }

}

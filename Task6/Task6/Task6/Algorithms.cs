using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task6
{
    /// <summary>
    /// Class for task 6 alpgorithms
    /// </summary>
    public class Algorithms
    {
        /// <summary>
        /// Implement an algorithm for inserting 
        /// one number into another so that the second 
        /// number occupies the position from bit j 
        /// to bit i (bits are numbered from right to left).
        /// </summary>
        /// <param name="number1">Firts number</param>
        /// <param name="number2">Second number</param>
        /// <param name="i">Bit i</param>
        /// <param name="j">Bit j</param>
        /// <returns>Rezult number</returns>
        public int First(int number1, int number2, int i, int j)
        {
            if (i >= j) throw new ArgumentException("i > = j");
            if (i < 0 || j < 0) throw new ArgumentException("i < 0 or j < 0");
            if (j >= sizeof(int) * 8) throw new ArgumentException("J is more than integer size");
            if (number2 > Math.Pow(2, j - i + 1)) throw new ArgumentException("Number does not fit");
            int Temp = int.MinValue;

            for (int k = i; k<=j; k++)
            {
                Temp = Temp - ((int)Math.Pow(2, k) + 1);
            }

            number1 = number1 & Temp;

            number2 = number2 << i;
            return number1 + number2;
        }

        /// <summary>
        /// Implement a recursive algorithm
        /// for searching the maximum 
        /// element in unsorted array.
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="i">Index in array</param>
        /// <param name="rezult">Maximum element</param>
        public void Second(int[] array, ref int i, ref int rezult)
        {
            if (i < 0) throw new ArgumentException("Index < 0");
            if (i < array.Length)
            {
                if (i == 0) rezult = 0;
                if (rezult < array[i]) rezult = array[i];
                i++;
                Second(array, ref i, ref rezult);
            }            
        }

        /// <summary>
        ///  Finds and return an index n for which
        ///  the sum of the elements to the left of
        ///  it is equal to the sum of the elements on 
        ///  the right. If such an index does not 
        ///  return -1.
        /// </summary>
        /// <param name="array">Given an array of integers</param>
        /// <returns>Index n</returns>
        public int Third(int[] array)
        {
            int leftSum = 0;
            int rightSum;
            for (int i = 0; i < array.Length; i++)
            {
                rightSum = 0;
                for (int j = i + 1; j < array.Length; j++)
                {
                    rightSum += array[j];
                }
                if (rightSum == leftSum) return i;
                leftSum = leftSum + array[i];
            }
            return -1;
        }

        /// <summary>
        ///  Concatenate alphabetized string, 
        ///  excluding duplicate characters.
        /// </summary>
        /// <param name="firstStr">First string to concatenate</param>
        /// <param name="secondStr">Second string to concatenate</param>
        /// <returns>Concatenated string excluding dublicate characters</returns>
        public string Fourth(string firstStr, string secondStr)
        {
            Regex regex = new Regex("^[a-z]{1,}$");
            if (!regex.IsMatch(firstStr))
                throw new ArgumentException("String does not contain " +
                    "letters from a-z");
            if (!regex.IsMatch(secondStr))
                throw new ArgumentException("String does not contain " +
                    "letters from a-z");
            StringBuilder builder = new StringBuilder();
            builder.Append(firstStr);
            builder.Append(secondStr);

            int i = 0;
            while (i < builder.Length -1)
            {
                if (builder[i] == builder[i + 1])
                {
                    builder.Remove(i + 1, 1);
                }
                else i++;
            }
            return builder.ToString();
        }

        /// <summary>
        /// FilterLucky that accepts a list of integers 
        /// and filters the list to only include the 
        /// elements that contain the digit 7.
        /// </summary>
        /// <param name="numbers">List of integers to exclude</param>
        public void Fifth_FilterLucky(List<int> numbers)
        {
            if (numbers.Count == 0) throw new ArgumentException("List is empty");
            int i = 0;
            while (i < numbers.Count)
            {
                if (Convert.ToString(numbers[i]).IndexOf("7") == -1)
                {
                    numbers.RemoveAt(i);
                }
                else i++;
            }
        }
    }
}

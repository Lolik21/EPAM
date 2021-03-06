﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Debug
{
    class Program
    {
        const int NUMBERS_COUNT = 1000;
        const int NUMBERS_PER_LINE = 10;
        static void Main(string[] args)
        {
            int[] NumbersArray = new int[NUMBERS_COUNT];
            for (int i = 0; i<NumbersArray.Length; i++)
            {
                NumbersArray[i] = i;
            }
            for (int i = 1; i<NumbersArray.Length-1; i = i + 2)
            {
                Swap(ref NumbersArray[i],ref NumbersArray[i + 1]);
            }
            for (int i = 0; i<NumbersArray.Length; i++)
            {
                Console.Write(NumbersArray[i] + " ");
                if (i % NUMBERS_PER_LINE == 0) Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Swap(ref int Value1, ref int Value2)
        {
            int Temp;
            Temp = Value1;
            Value1 = Value2;
            Value2 = Temp;       
        }
    }
}

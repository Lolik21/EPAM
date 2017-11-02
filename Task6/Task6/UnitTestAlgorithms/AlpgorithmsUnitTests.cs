using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;
using System.Collections.Generic;

namespace UnitTestAlgorithms
{
    [TestClass]
    public class AlpgorithmsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void First_IMoreThenJ_ExceptionExpected()
        {
            //arrange
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.First(100, 100, 100, 1);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void First_ILessThen0_ExceptionExpected()
        {
            //arrange
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.First(100, 100, -1, 1);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void First_IAndJLessThen0_ExceptionExpected()
        {
            //arrange
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.First(100, 100, -3, -1);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void First_JIsToBig_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.First(100, 100, 1, 32);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void First_NumberDoesNotFit_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.First(100, 100, 30, 31);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        public void First_8And2_67108872Expected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            //act
            int rez = algorithms.First(8, 2, 25, 26);
            //assert
            Assert.AreEqual(67108872, rez);
        }

        [TestMethod]
        public void First_8And2_10Expected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            //act
            int rez = algorithms.First(8, 2, 0, 1);
            //assert
            Assert.AreEqual(10, rez);
        }

        [TestMethod]
        public void Second_IntArray_1042ExpectedInRez()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 1005;
            array[2] = 5;
            array[3] = 1042;
            array[4] = 1;
            int rez = 0;
            int i = 0;
            //act

            algorithms.Second(array,ref i, ref rez);
            //assert
            Assert.AreEqual(1042, rez);
        }

        [TestMethod]
        public void Second_IntArray_104505ExpectedInRez()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[5];
            array[0] = 515;
            array[1] = 104505;
            array[2] = 541;
            array[3] = 1042;
            array[4] = 641;
            int rez = 0;
            int i = 0;
            //act

            algorithms.Second(array, ref i, ref rez);
            //assert
            Assert.AreEqual(104505, rez);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Second_IndexLessThen0_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[2];
            array[0] = 515;
            array[1] = 104505;
            int rez = 0;
            int i = -100;
            //act
            algorithms.Second(array,ref i,ref rez);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        public void Third_LeftSumRightSum_2Expected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 2;
            array[3] = 2;
            array[4] = 1;

            //act
            int rez = algorithms.Third(array);
            //assert
            Assert.AreEqual(2, rez);
        }

        [TestMethod]
        public void Third_LeftSumRightSum_3Expected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 2;
            array[3] = 2;
            array[4] = 5;

            //act
            int rez = algorithms.Third(array);
            //assert
            Assert.AreEqual(3, rez);
        }

        [TestMethod]
        public void Third_LeftSumRightSum_Minus1Expected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2413;
            array[2] = 2;
            array[3] = 241;
            array[4] = 5;

            //act
            int rez = algorithms.Third(array);
            //assert
            Assert.AreEqual(-1, rez);
        }

        [TestMethod]
        public void Fourth_StringConcatinate_adfadsExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            string First = "adff";
            string Second = "ads";

            //act
            string rez = algorithms.Fourth(First, Second);
            //assert
            Assert.AreEqual(rez, "adfads");
        }

        [TestMethod]
        public void Fourth_StringConcatinate_adfsadsExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            string First = "adffssss";
            string Second = "adsssssssss";

            //act
            string rez = algorithms.Fourth(First, Second);
            //assert
            Assert.AreEqual(rez, "adfsads");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fourth_BigLettersInStr_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            string First = "adffssss";
            string Second = "adssGJSDAsssssss";
            //act
            string rez = algorithms.Fourth(First, Second);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fourth_NumbersInStr_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            string First = "adf412fssss";
            string Second = "adssssssss";
            //act
            string rez = algorithms.Fourth(First, Second);
            //assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fifth_FilterLucky_EmptyList_ExceptionExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            //act
            algorithms.Fifth_FilterLucky(new List<int>());
            //assert is handled by ExpectedException
        }

        [TestMethod]
        public void Fifth_FilterLucky_FilterNumbers_NewListExpected()
        {
            //arrange 
            Algorithms algorithms = new Algorithms();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(5);
            list.Add(7);
            list.Add(19283);
            list.Add(19742);
            //act
            algorithms.Fifth_FilterLucky(list);
            //assert
            Assert.AreEqual(list[0], 7);
            Assert.AreEqual(list[1], 19742);
        }

    }
}

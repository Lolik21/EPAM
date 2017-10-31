using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace UnitTestForPoint
{
    /// <summary>
    /// Tests for Geometric point class
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Tests operator + with two points
        /// </summary>
        [TestMethod]
        public void OperatorPlus_CoodsAdded_10CoordX10CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 5,
                CoordY = 5
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 5,
                CoordY = 5
            };

            GeometricPoint point3 = new GeometricPoint();

            //act
            point3 = point1 + point2;

            //assert
            Assert.AreEqual(point3.CoordX, 10);
            Assert.AreEqual(point3.CoordY, 10);
        }

        /// <summary>
        /// Tests operator + with two points
        /// </summary>
        [TestMethod]
        public void OperatorPlus_CoodsAdded_30CoordX20CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 10
            };

            GeometricPoint point3 = new GeometricPoint();

            //act
            point3 = point1 + point2;

            //assert
            Assert.AreEqual(point3.CoordX, 30);
            Assert.AreEqual(point3.CoordY, 20);

        }

        /// <summary>
        /// Tests operator - with two points
        /// </summary>
        [TestMethod]
        public void OperatorMinus_CoodsSubstracted_0CoordX0CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            GeometricPoint point3 = new GeometricPoint();

            //act
            point3 = point1 - point2;

            //assert
            Assert.AreEqual(point3.CoordX, 0);
            Assert.AreEqual(point3.CoordY, 0);

        }

        /// <summary>
        /// Tests operator - with two points
        /// </summary>
        [TestMethod]
        public void OperatorMinus_CoodsSubstracted_10CoordX10CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            GeometricPoint point3 = new GeometricPoint();

            //act
            point3 = point1 - point2;

            //assert
            Assert.AreEqual(point3.CoordX, 10);
            Assert.AreEqual(point3.CoordY, 10);

        }
        /// <summary>
        /// Tests operator ++ with two points
        /// </summary>
        [TestMethod]
        public void OperatorPlusPlus_CoodsAdded_11CoordX11CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            //act
            point1++;

            //assert
            Assert.AreEqual(point1.CoordX, 11);
            Assert.AreEqual(point1.CoordY, 11);

        }

        /// <summary>
        /// Tests operator ++ with two points
        /// </summary>
        [TestMethod]
        public void TwoOperatorPlusPlus_CoodsAdded_12CoordX12CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            //act
            point1++;
            point1++;

            //assert
            Assert.AreEqual(point1.CoordX, 12);
            Assert.AreEqual(point1.CoordY, 12);

        }

        /// <summary>
        /// Tests operator -- with two points
        /// </summary>
        [TestMethod]
        public void OperatorMinusMinus_CoodsSubstracted_9CoordX9CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            //act
            point1--;

            //assert
            Assert.AreEqual(point1.CoordX, 9);
            Assert.AreEqual(point1.CoordY, 9);

        }

        /// <summary>
        /// Tests operator -- with two points
        /// </summary>
        [TestMethod]
        public void TwoOperatorMinusMinus_CoodsSubstracted_8CoordX8CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            //act
            point1--;
            point1--;

            //assert
            Assert.AreEqual(point1.CoordX, 8);
            Assert.AreEqual(point1.CoordY, 8);
        }

        /// <summary>
        /// Tests operator - with two points
        /// </summary>
        [TestMethod]
        public void OperatorSigleMinus_CoodsInversed_Minus10CoordXMinus10CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 10,
                CoordY = 10
            };

            //act
            point1 = -point1;

            //assert
            Assert.AreEqual(point1.CoordX, -10);
            Assert.AreEqual(point1.CoordY, -10);
        }

        /// <summary>
        /// Tests operator - with two points
        /// </summary>
        [TestMethod]
        public void OperatorSigleMinus_CoodsInversed_Minus20CoordXMinus20CoordYExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            //act
            point1 = -point1;

            //assert
            Assert.AreEqual(point1.CoordX, -20);
            Assert.AreEqual(point1.CoordY, -20);
        }

        /// <summary>
        /// Tests operator == with two points
        /// </summary>
        [TestMethod]
        public void OperatorEqual_CoodsChecked_PointsEqualExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            //act
            //assert
            Assert.IsTrue(point1 == point2);
        }

        /// <summary>
        /// Tests operator == with two points
        /// </summary>
        [TestMethod]
        public void OperatorEqual_CoodsChecked_PointsNotEqualExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 21,
                CoordY = 21
            };

            //act
            //assert
            Assert.IsFalse(point1 == point2);
        }

        /// <summary>
        /// Tests operator != with two points
        /// </summary>
        [TestMethod]
        public void OperatorNotEqual_CoodsChecked_TrueExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 21,
                CoordY = 21
            };

            //act
            //assert
            Assert.IsTrue(point1 != point2);
        }

        /// <summary>
        /// Tests operator != with two points
        /// </summary>
        [TestMethod]
        public void OperatorNotEqual_CoodsChecked_FalseExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            //act
            //assert
            Assert.IsFalse(point1 != point2);
        }

        /// <summary>
        /// Tests static class extension method for copying one point to another
        /// </summary>
        [TestMethod]
        public void ClassExtension_CoodstoNewCoords_PointsEqualsExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            GeometricPoint point2 = new GeometricPoint();

            //act
            point2.ToNewPoint(point1);
            //assert
            Assert.IsTrue(point1 == point2);
        }

        /// <summary>
        /// Tests static class extension method for copying one point to another
        /// </summary>
        [TestMethod]
        public void SecondTestClassExtension_CoodstoNewCoords_PointsEqualsExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 30,
                CoordY = 30
            };
            GeometricPoint point2 = new GeometricPoint();

            //act
            point2.ToNewPoint(point1);
            //assert
            Assert.IsTrue(point1 == point2);
        }

        /// <summary>
        /// Tests point to string cast
        /// </summary>
        [TestMethod]
        public void ToStringCast_PointsToString_PointsStringExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 30,
                CoordY = 30
            };

            //act
            //assert
            Assert.AreEqual((string)point1,"(30,30)");
        }

        /// <summary>
        /// Tests point to string cast
        /// </summary>
        [TestMethod]
        public void SecondToStringCast_PointsToString_PointsStringExpected()
        {
            //arrange
            GeometricPoint point1 = new GeometricPoint()
            {
                CoordX = 20,
                CoordY = 20
            };

            //act
            //assert
            Assert.AreEqual((string)point1, "(20,20)");
        }

    }
}

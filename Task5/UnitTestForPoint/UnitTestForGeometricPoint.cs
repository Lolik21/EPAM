using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace UnitTestForPoint
{
    [TestClass]
    public class UnitTests
    {
        //[TestMethod]
        //public void OperatorPlus_CoodsAdded_10CoordX10CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 5,
        //        CoordY = 5
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 5,
        //        CoordY = 5
        //    };

        //    GeometricPoint point3 = new GeometricPoint();

        //    //act
        //    point3 = point1 + point2;

        //    //assert
        //    Assert.AreEqual(point3.CoordX, 10);
        //    Assert.AreEqual(point3.CoordY, 10);
        //}

        //[TestMethod]
        //public void OperatorPlus_CoodsAdded_30CoordX20CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 10
        //    };

        //    GeometricPoint point3 = new GeometricPoint();

        //    //act
        //    point3 = point1 + point2;

        //    //assert
        //    Assert.AreEqual(point3.CoordX, 30);
        //    Assert.AreEqual(point3.CoordY, 20);

        //}

        //[TestMethod]
        //public void OperatorMinus_CoodsSubstracted_0CoordX0CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    GeometricPoint point3 = new GeometricPoint();

        //    //act
        //    point3 = point1 - point2;

        //    //assert
        //    Assert.AreEqual(point3.CoordX, 0);
        //    Assert.AreEqual(point3.CoordY, 0);

        //}

        //[TestMethod]
        //public void OperatorMinus_CoodsSubstracted_10CoordX10CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    GeometricPoint point3 = new GeometricPoint();

        //    //act
        //    point3 = point1 - point2;

        //    //assert
        //    Assert.AreEqual(point3.CoordX, 10);
        //    Assert.AreEqual(point3.CoordY, 10);

        //}

        //[TestMethod]
        //public void OperatorPlusPlus_CoodsAdded_11CoordX11CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    //act
        //    point1++;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, 11);
        //    Assert.AreEqual(point1.CoordY, 11);

        //}

        //[TestMethod]
        //public void TwoOperatorPlusPlus_CoodsAdded_12CoordX12CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    //act
        //    point1++;
        //    point1++;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, 12);
        //    Assert.AreEqual(point1.CoordY, 12);

        //}

        //[TestMethod]
        //public void OperatorMinusMinus_CoodsSubstracted_9CoordX9CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    //act
        //    point1--;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, 9);
        //    Assert.AreEqual(point1.CoordY, 9);

        //}

        //[TestMethod]
        //public void TwoOperatorMinusMinus_CoodsSubstracted_8CoordX8CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    //act
        //    point1--;
        //    point1--;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, 8);
        //    Assert.AreEqual(point1.CoordY, 8);
        //}

        //[TestMethod]
        //public void OperatorSigleMinus_CoodsInversed_Minus10CoordXMinus10CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 10,
        //        CoordY = 10
        //    };

        //    //act
        //    point1 = -point1;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, -10);
        //    Assert.AreEqual(point1.CoordY, -10);
        //}

        //[TestMethod]
        //public void OperatorSigleMinus_CoodsInversed_Minus20CoordXMinus20CoordYExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    //act
        //    point1 = -point1;

        //    //assert
        //    Assert.AreEqual(point1.CoordX, -20);
        //    Assert.AreEqual(point1.CoordY, -20);
        //}

        //[TestMethod]
        //public void OperatorEqual_CoodsChecked_PointsEqualExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    //act
        //    //assert
        //    Assert.IsTrue(point1 == point2);
        //}

        //[TestMethod]
        //public void OperatorEqual_CoodsChecked_PointsNotEqualExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 21,
        //        CoordY = 21
        //    };

        //    //act
        //    //assert
        //    Assert.IsFalse(point1 == point2);
        //}

        //[TestMethod]
        //public void OperatorNotEqual_CoodsChecked_TrueExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 21,
        //        CoordY = 21
        //    };

        //    //act
        //    //assert
        //    Assert.IsTrue(point1 != point2);
        //}

        //[TestMethod]
        //public void OperatorNotEqual_CoodsChecked_FalseExpected()
        //{
        //    //arrange
        //    GeometricPoint point1 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    GeometricPoint point2 = new GeometricPoint()
        //    {
        //        CoordX = 20,
        //        CoordY = 20
        //    };

        //    //act
        //    //assert
        //    Assert.IsFalse(point1 != point2);
        //}

    }
}

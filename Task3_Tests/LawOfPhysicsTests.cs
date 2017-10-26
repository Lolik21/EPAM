using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_Classes;
using System.Collections.Generic;

namespace Task3_Tests
{
    /// <summary>
    /// Contains tests for LawOfPhysics class
    /// </summary>
    [TestClass]
    public class LawOfPhysicsTests
    {
        /// <summary>
        /// Tests setting affected objects
        /// </summary>
        [TestMethod]
        public void LawOfPhysics_SetAffectedList_GetNewAffectedListCount()
        {
            // arrange
            List<object> list = new List<object>();
            
            for (int i = 0; i< 10000; i++)
            {
                list.Add(new object());
            }

            // act
            LawOfPhysics law = new LawOfPhysics(list, 1000);
            // assert
            Assert.AreEqual(law.GetAffectedObjectsCount(), 10000);

        }

        /// <summary>
        /// Tests adding to affected objects list
        /// </summary>
        [TestMethod]
        public void AddToAffectedObjects_PlusOneNewObject_GetNewAffectedListCount()
        {
            // arrange
            List<object> list = new List<object>();
            list.Add(new object());
            list.Add(new object());
            object MyObj = new object();
            LawOfPhysics law = new LawOfPhysics(list, 1000);
            // act
            law.AddToAffectedObjects(MyObj);
            // assert
            Assert.AreEqual(law.GetAffectedObjectsCount(), 3);
        }

        /// <summary>
        /// Tests removing from affected objects list
        /// </summary>
        [TestMethod]
        public void RemoveAffectedObject_MinusOneNewObject_GetNewAffectedListCount()
        {
            // arrange
            List<object> list = new List<object>();
            list.Add(new object());
            list.Add(new object());
            object MyObj = new object();
            list.Add(MyObj);
            LawOfPhysics law = new LawOfPhysics(list, 1000);
            // act
            law.RemoveFromAffectedObject(MyObj);
            // assert
            Assert.AreEqual(law.GetAffectedObjectsCount(), 2);
        }

        /// <summary>
        /// Tests setting of law sighinificance in ctor
        /// </summary>
        [TestMethod]
        public void GetLawSignificance_CreateNewLawWithSignificance_GetNewSignificance()
        {
            // arrange
            List<object> list = new List<object>();
            list.Add(new object());
            list.Add(new object());
            // act
            LawOfPhysics law = new LawOfPhysics(list, 1000);
            // assert
            Assert.AreEqual(law.GetLawSignificance(), 1000);
        }
    }
}

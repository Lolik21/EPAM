using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_Classes;
using System.Threading;

namespace Task3_Tests
{
    /// <summary>
    /// Contains tests for class TrafficLight
    /// </summary>
    [TestClass]
    public class TrafficLightTests
    {
        /// <summary>
        /// Tests height set
        /// </summary>
        [TestMethod]
        public void TraficLight_SetHeight_NewHeight()
        {
            // arrange
            // act 
            TrafficLight light = new TrafficLight(100, 100, 1000);
            // assert
            Assert.AreEqual(light.Height, 100);
        }

        /// <summary>
        /// Tests width set
        /// </summary>
        [TestMethod]
        public void TraficLight_SetWidth_NewWidth()
        {
            // arrange
            // act 
            TrafficLight light = new TrafficLight(100, 999, 1000);
            // assert
            Assert.AreEqual(light.Width, 999);
        }

        /// <summary>
        /// Tests traffic light color(by default - Red)
        /// </summary>
        [TestMethod]
        public void GetLight_GetDefaultLight_DefaultLight()
        {
            // arrange
            TrafficLight light = new TrafficLight(100, 999, 1000);
            // act
            string strLight = light.GetLight();
            // assert
            Assert.AreEqual(strLight, "Red");
        }

        /// <summary>
        /// Tests traffic light changing
        /// </summary>
        [TestMethod]
        public void SwitchAction_SwitchLight_NewLight()
        {
            // arrange
            TrafficLight light = new TrafficLight(100, 999, 1000);
            // act
            Thread.Sleep(1100);
            string strLight = light.GetLight();
            // assert
            Assert.AreEqual(strLight, "Yellow");
        }

    }
}

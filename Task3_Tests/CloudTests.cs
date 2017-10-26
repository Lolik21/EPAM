using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_Classes;
using System.Drawing;
using System.Threading;

namespace Task3_Tests
{
    /// <summary>
    /// Contains tests for class Cloud
    /// </summary>
    [TestClass]
    public class CloudTests
    {
        /// <summary>
        /// Tests normal cloud speed
        /// </summary>
        [TestMethod]
        public void Cloud_NormalSpeedSet_SpeedSeted()
        {
            // arrange
            // act
            Cloud cl = new Cloud(Color.Black, 150, 100, 100);
            // assert
            Assert.AreEqual(cl.Speed, 150);
        }

        /// <summary>
        /// Tests imposible cloud speed set
        /// </summary>
        [TestMethod]
        public void Cloud_ImposibleSpeedSet_0Speed()
        {
            // arrange
            // act
            Cloud cl = new Cloud(Color.Black, 3000, 100, 100);
            // assert
            Assert.AreEqual(cl.Speed, 0);
        }

        /// <summary>
        /// Tests imposible cloud area set
        /// </summary>
        [TestMethod]
        public void Cloud_ImposibleCloudAreaSet_0CloudArea()
        {
            // arrange
            // act
            Cloud cl = new Cloud(Color.Black, 3000,100,-100);
            // assert
            Assert.AreEqual(cl.CloudArea, 0);
        }

        /// <summary>
        /// Tests imposible shadow area set
        /// </summary>
        [TestMethod]
        public void Cloud_ImposibleShadowAreaSet_0ShadowArea()
        {
            // arrange
            // act
            Cloud cl = new Cloud(Color.Black, 3000, -100, 100);
            // assert
            Assert.AreEqual(cl.ShadowArea, 0);
        }

        /// <summary>
        /// Tests rain action with defult time (2000mls)
        /// </summary>
        [TestMethod]
        public void DoRain_1RainAdd_Plus1RainCount()
        {
            // arrange
            Cloud cl = new Cloud(Color.Black, 3000, -100, 100);
            // act
            Thread.Sleep(2500);
            // assert
            Assert.AreEqual(cl.GetRainCount(), 1);
        }

        /// <summary>
        /// Tests rain action with setted time
        /// </summary>
        [TestMethod]
        public void DoRain_SetNewTime_Plus2RainCount()
        {
            // arrange
            Cloud cl = new Cloud(Color.Black, 3000, -100, 100);
            cl.SetTimerTime(1000);
            // act
            Thread.Sleep(2500);
            // assert
            Assert.AreEqual(cl.GetRainCount(), 2);            
        }
    }
}

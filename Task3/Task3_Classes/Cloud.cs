using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Task3_Classes
{
    /// <summary>
    /// Describes usual cloud
    /// </summary>
    public class Cloud
    {
        private const int SPEED_LIMIT = 200;
        private const int DEFAULT_RAIN_PER = 2000;
        private Timer _rainTimer;
        private int _rainCount = 0;

        /// <summary>
        /// Creates new cloud according to passing parameters
        /// if Speed is more than max speed, than cloud speed is 0
        /// if shadow area is less than 0 shadow area will be 0
        /// if cloud area is less than 0 shadow area will be 0
        /// Cloud will perform rain at regular intervals 
        /// </summary>
        /// <param name="color">Cloud color</param>
        /// <param name="speed">Cloud speed in km/h</param>
        /// <param name="shadowArea">Cloud shadow area in km^2</param>
        /// <param name="cloudAre">Cloud area in km^2</param>
        public Cloud(Color color, int speed, double shadowArea, double cloudAre)
        {
            Color = color;
            if (cloudAre > 0) CloudArea = cloudAre;
            else cloudAre = 0;    
            if (shadowArea > 0) ShadowArea = shadowArea;
            else shadowArea = 0;
            if (speed > SPEED_LIMIT || speed < 0) Speed = 0;
            else Speed = speed;
            _rainTimer = new Timer(DoRain, null, DEFAULT_RAIN_PER, DEFAULT_RAIN_PER);
        }
        /// <summary>
        /// Gives access to information about the color of the cloud
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// Gives access to information about the cloud area
        /// </summary>
        public double CloudArea { get; private set; }

        /// <summary>
        /// Gives access to information about the cloud shadow area
        /// </summary>
        public double ShadowArea { get; private set; }

        /// <summary>
        /// Gives access to information about the cloud spped
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Sets new time for perform rain action
        /// </summary>
        /// <param name="time">Time in milliseconds</param>
        public void SetTimerTime(int time)
        {
            _rainTimer.Dispose();
            _rainTimer = new Timer(DoRain, null, time, time);
        }

        /// <summary>
        /// Gets rain count
        /// </summary>
        /// <returns>Rain count</returns>
        public int GetRainCount()
        {
            return _rainCount;
        }

        private void DoRain(object obj)
        {
            if (_rainCount == int.MaxValue) _rainCount = 0;
            _rainCount++;
        }
    }
}

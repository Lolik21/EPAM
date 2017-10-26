using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3_Classes
{
    /// <summary>
    /// Describes usual traffic light
    /// </summary>
    public class TrafficLight
    {
        private string[] _light = {"Red", "Yellow", "Green"};
        private int _lightInd;

        /// <summary>
        /// Creates new traffic light according to passing parameters.
        /// Sets timer to perform light switch action
        /// </summary>
        /// <param name="height">Height of the traffic light in meters</param>
        /// <param name="width">Width of the traffic light in meters</param>
        /// <param name="switchTime">Switch time of the traffic light</param>
        public TrafficLight(double height, double width, int switchTime)
        {
            _lightInd = 0;
            Height = height;
            Width = width;
            Timer switchTimer = new Timer(SwitchAction,null,switchTime,switchTime);
        }

        /// <summary>
        /// Gives access to information about traffic light height in meters
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Gives access to information about traffic light width in meters
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Gets traffic light color
        /// </summary>
        /// <returns>Traffic light color</returns>
        public string GetLight()
        {
            return _light[_lightInd];
        }

        /// <summary>
        /// Event occurs at the end of the traffic light switch
        /// </summary>
        public event EventHandler onLightChanged;

        /// <summary>
        /// Event occurs at the beginning of the traffic light switch
        /// </summary>
        public event EventHandler onLightChange;

        private void SwitchAction(object obj)
        {
            onLightChange?.Invoke(this, new EventArgs());
            _lightInd = _lightInd + 1;
            if (_lightInd % _light.Length == 0)
            {
                _lightInd = 0;
            }
            onLightChanged?.Invoke(this, new EventArgs());
        }
    }
}

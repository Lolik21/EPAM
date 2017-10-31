using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Extenssion class for GeometricPoint
    /// </summary>
    public static class PointExtenssion
    {
        /// <summary>
        /// Copy position of one point to another
        /// </summary>
        /// <param name="point">Point for copy</param>
        /// <param name="newPoint">Point to copy to</param>
        public static void ToNewPoint(this GeometricPoint point, GeometricPoint newPoint)
        {
            point.CoordX = newPoint.CoordX;
            point.CoordY = newPoint.CoordY;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Class describes simble geometric point
    /// </summary>
    public class GeometricPoint
    {
        /// <summary>
        /// X coordinate for point
        /// </summary>
        public int CoordX { get; set; }
        /// <summary>
        /// Y coordinate for point
        /// </summary>
        public int CoordY { get; set; }

        /// <summary>
        /// Operator for adding one point coordinates to another
        /// </summary>
        /// <param name="point1">First point to add</param>
        /// <param name="point2">Second point to add</param>
        /// <returns>New point this the sum of two previous</returns>
        public static GeometricPoint operator +(GeometricPoint point1, GeometricPoint point2)
        {
            GeometricPoint newPoint = new GeometricPoint
            {
                CoordX = point1.CoordX + point2.CoordX,
                CoordY = point1.CoordY + point2.CoordY
            };
            return newPoint;
        }

        /// <summary>
        /// Operator for subtracting one point coordinates from another
        /// </summary>
        /// <param name="point1">First point to subtract</param>
        /// <param name="point2">Second point to subtract</param>
        /// <returns>New point with subtracted coordinates</returns>
        public static GeometricPoint operator -(GeometricPoint point1, GeometricPoint point2)
        {
            GeometricPoint newPoint = new GeometricPoint
            {
                CoordX = point1.CoordX - point2.CoordX,
                CoordY = point1.CoordY - point2.CoordY
            };
            return newPoint;
        }

        /// <summary>
        /// Unary operator for inverting point coodinats
        /// </summary>
        /// <param name="point1">Point for inverting</param>
        /// <returns>Inverted point</returns>
        public static GeometricPoint operator -(GeometricPoint point1)
        {
            point1.CoordX = -point1.CoordX;
            point1.CoordY = -point1.CoordY;
            return point1;
        }

        /// <summary>
        /// Operator ++ to add 1 to each coordinate
        /// </summary>
        /// <param name="point1">Point to add coordinates</param>
        /// <returns>Point with added coordinates</returns>
        public static GeometricPoint operator ++(GeometricPoint point1)
        {
            point1.CoordX += 1;
            point1.CoordY += 1;
            return point1;
        }

        /// <summary>
        /// Operator -- to subtract 1 from each coordinate
        /// </summary>
        /// <param name="point1">Point to subtract coordinates</param>
        /// <returns>Point with subtacted coordinates</returns>
        public static GeometricPoint operator --(GeometricPoint point1)
        {
            point1.CoordX -= 1;
            point1.CoordY -= 1;
            return point1;
        }

        /// <summary>
        /// Not Equals operator for comparing two points
        /// </summary>
        /// <param name="point1">First point to compare</param>
        /// <param name="point2">Second point to compare</param>
        /// <returns>if First point coodinates is not equal to 
        /// second point coodinates returns true overwise false</returns>
        public static bool operator !=(GeometricPoint point1, GeometricPoint point2)
        {
            if (point1.CoordX != point1.CoordX || point1.CoordY != point2.CoordY)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Equals operator for comparing two points
        /// </summary>
        /// <param name="point1">First point to compare</param>
        /// <param name="point2">Second point to compare</param>
        /// <returns>if First point coodinates is equal to 
        /// second point coodinates returns true overwise false</returns>
        public static bool operator ==(GeometricPoint point1, GeometricPoint point2)
        {
            if (point1.CoordX == point1.CoordX && point1.CoordY == point2.CoordY)
            {
                return true;
            }                
            return false;
        }

        /// <summary>
        /// Explicit cast to string
        /// </summary>
        /// <param name="point">Point to cast to string</param>
        public static explicit operator string(GeometricPoint point)
        {
            return string.Format("({0},{1})", point.CoordX, point.CoordY);
        }

        /// <summary>
        /// Point to string method
        /// </summary>
        /// <returns>Returns string with coordinates "(X,Y)"</returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", CoordX, CoordY);
        }

        /// <summary>
        /// Compate to points by coordinates
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if obj point coordinates is equal to 
        /// this point coordinates</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GeometricPoint point = obj as GeometricPoint;
            if (point == null) return false;
            if (point.CoordX == CoordX && point.CoordY == CoordY) return true;
            return false;
        }

        /// <summary>
        /// Gets hash code from point
        /// </summary>
        /// <returns>0-4 depends on coordinates</returns>
        public override int GetHashCode()
        {
            if (CoordX >= 0 && CoordY >= 0) return 0;
            if (CoordX < 0 && CoordY >= 0) return 1;
            if (CoordX >= 0 && CoordY < 0) return 3;
            else return 4;
        }

    }
}

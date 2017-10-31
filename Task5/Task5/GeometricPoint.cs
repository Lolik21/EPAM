using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class GeometricPoint
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public static GeometricPoint operator +(GeometricPoint point1, GeometricPoint point2)
        {
            GeometricPoint newPoint = new GeometricPoint
            {
                CoordX = point1.CoordX + point2.CoordX,
                CoordY = point1.CoordY + point2.CoordY
            };
            return newPoint;
        }

        public static GeometricPoint operator -(GeometricPoint point1, GeometricPoint point2)
        {
            GeometricPoint newPoint = new GeometricPoint
            {
                CoordX = point1.CoordX - point2.CoordX,
                CoordY = point1.CoordY - point2.CoordY
            };
            return newPoint;
        }

        public static GeometricPoint operator -(GeometricPoint point1)
        {
            point1.CoordX = -point1.CoordX;
            point1.CoordY = -point1.CoordY;
            return point1;
        }

        public static GeometricPoint operator ++(GeometricPoint point1)
        {
            point1.CoordX += 1;
            point1.CoordY += 1;
            return point1;
        }

        public static GeometricPoint operator --(GeometricPoint point1)
        {
            point1.CoordX -= 1;
            point1.CoordY -= 1;
            return point1;
        }

        public static bool operator !=(GeometricPoint point1, GeometricPoint point2)
        {
            if (point1.CoordX != point1.CoordX || point1.CoordY != point2.CoordY)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(GeometricPoint point1, GeometricPoint point2)
        {
            if (point1.CoordX == point1.CoordX && point1.CoordY == point2.CoordY)
            {
                return true;
            }                
            return false;
        }

        public static explicit operator string(GeometricPoint point)
        {
            return string.Format("({0},{1})", point.CoordX, point.CoordY);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", CoordX, CoordY);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GeometricPoint point = obj as GeometricPoint;
            if (point == null) return false;
            if (point.CoordX == CoordX && point.CoordY == CoordY) return true;
            return false;
        }

        public override int GetHashCode()
        {
            if (CoordX >= 0 && CoordY >= 0) return 0;
            if (CoordX < 0 && CoordY >= 0) return 1;
            if (CoordX >= 0 && CoordY < 0) return 3;
            else return 4;
        }

    }
}

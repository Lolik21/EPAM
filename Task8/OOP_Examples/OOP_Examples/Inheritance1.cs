using System.Drawing;
using System.Reflection;

namespace OOP_Examples
{
    /// <summary>
    /// Bad example of inheritance
    /// because Arrow class is inherited from
    /// Rectangle class and Rectangle class have
    /// method GetSquare, so Arrow class also have
    /// method GetSquare.
    /// </summary>
    public class Inheritance1
    {
        class Rectangle
        {
            protected int _x1;
            protected int _x2;
            protected int _y1;
            protected int _y2;

            public Rectangle(int x1, int x2, int y1, int y2)
            {
                _x1 = x1;
                _x2 = x2;
                _y1 = y1;
                _y2 = y2;
            }

            /// <summary>
            /// Get's square of the rectangle
            /// </summary>
            /// <returns>square of the rectangle</returns>
            public double GetSquare()
            {
                var width = _x2 - _x1;
                var height = _y2 - _y2;

                return width * height;
            }
        }

        class Arrow : Rectangle
        {
            public Arrow(int x1, int x2, int y1, int y2) : base(x1, x2, y1, y2)
            {
            }

            /// <summary>
            /// Get's arrow starting point
            /// </summary>
            /// <returns>Arrow starting point</returns>
            public Point GetStartPoint()
            {
                return new Point(_x1,_y1);
            }
            /// <summary>
            /// Get's arrow end point
            /// </summary>
            /// <returns>Arrow end point</returns>
            public Point GetEndPoint()
            {
                return  new Point(_x2,_y2);
            }
        }
    }
}
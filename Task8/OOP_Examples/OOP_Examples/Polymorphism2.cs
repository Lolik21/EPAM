using System.Drawing;

namespace OOP_Examples
{
    /// <summary>
    /// Bad example of polymorphism
    /// because in MySuperPuperLine we
    /// created new virtual Draw method 
    /// after we sealed Draw method in
    /// previous class Line. We need to inherite
    /// class MySuperPuperLine from Figure and override
    /// method Draw.  
    /// </summary>
    public class Polymorphism2
    {
        abstract class Figure
        {
            private Point x;
            private Point y;

            protected Figure(Point y, Point x)
            {
                this.y = y;
                this.x = x;
            }

            public abstract void Draw();
        }

        class Line : Figure
        {
            public Line(Point y, Point x) : base(y, x)
            {
            }

            public sealed override void Draw()
            {
                //implementation
            }
        }

        class MySuperPuperLine : Line
        {
            public MySuperPuperLine(Point y, Point x) : base(y, x)
            {
            }

            public virtual void Draw()
            {
                // some super puper implementation
            }
        }
    }
}
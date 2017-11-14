namespace OOP_Examples
{
    /// <summary>
    /// Bad example of polymorphism
    /// becouse in Square class threre is no
    /// new functionality added in GetSquare method
    /// </summary>
    public class Polymorphism1
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

            public virtual double GetSquare()
            {
                var width = _x2 - _x1;
                var height = _y2 - _y2;

                return width * height;
            }
        }

        class Square : Rectangle
        {
            public Square(int x1, int x2, int y1, int y2) : base(x1, x2, y1, y2)
            {
            }

            public override double GetSquare()
            {
                return base.GetSquare();
            }
        }
    }
}
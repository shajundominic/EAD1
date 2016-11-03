// sample solution to Lab 3
// author GC

using System;

namespace Shape
{
    // a Vertex
    public class Vertex
    {
        public int X {get; set;}
        public int Y { get; set; }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override String ToString()
        {
            return "X: " + X + "Y: " + Y;
        }
    }

    // enumerated type
    public enum ShapeColor
    {
        Red, Green, Blue
    }

    // abstract shape (2D) class
    public abstract class Shape
    {
        public ShapeColor Color { get; set; }

        // constructor
        public Shape(ShapeColor color)
        {
            Color = color;
        }

        // show
        public override String ToString()
        {
            return "A " + Color + " shape";
        }

        public abstract void Translate(Vertex amount);
    }

    public class Line : Shape
    {
        private Vertex v1, v2;

        // no default constructor

        public Line(int x1, int y1, int x2, int y2, ShapeColor c)
            : base(c)
        {
            this.v1 = new Vertex(x1, y1);
            this.v2 = new Vertex(x2, y2);
        }

        // read/write properties for x and y coords

        public int X1
        {
            get
            {
                return v1.X;
            }

            set
            {
                v1.X = value;
            }
        }


        public int Y1
        {
            get
            {
                return v1.Y;
            }

            set
            {
                v1.Y = value;
            }
        }

        public int X2
        {
            get
            {
                return v2.X;
            }

            set
            {
                v2.X = value;
            }
        }

        public int Y2
        {
            get
            {
                return v2.Y;
            }

            set
            {
                v2.Y = value;
            }
        }


        // show
        public override String ToString()
        {
            return "A " + Color + " Line from " + X1 + "," + Y1 + " to " + X2 + "," + Y2;
        }

        // move the line
        public override void Translate(Vertex amount)
        {
            v1.X += amount.X;
            v2.X += amount.X;
            v1.Y += amount.Y;
            v2.Y += amount.Y;
        }

    }

    public class Circle : Shape
    {
        private Vertex origin;
        public int Radius { get; set; }

        // no default constructor

        public Circle(int x1, int y1, int radius, ShapeColor c) : base(c)
        {
            this.origin = new Vertex(x1, y1);
            Radius = radius;
        }

        public int X
        {
            get
            {
                return origin.X;
            }

            set
            {
                origin.X = value;
            }
        }


        public int Y
        {
            get
            {
                return origin.Y;
            }

            set
            {
                origin.Y = value;
            }
        }

        // calc area
        public virtual double CalcArea()
        {
            return Math.PI * Radius * Radius;
        }

        // show
        public override String ToString()
        {
            return "A " + Color + " Circle at " + X + "," + Y + " radius " + Radius + " area " + " " + this.CalcArea();
        }

        // move the circle
        public override void Translate(Vertex amount)
        {
            origin.X += amount.X;
            origin.Y += amount.Y;
        }

       

    }

    // test class
    class Test
    {
        public static void Main()
        {
            Shape[] shapes = { new Line(2, 2, 3, 3, ShapeColor.Green), new Circle(5, 5, 50, ShapeColor.Blue) };

            foreach (Shape s in shapes)
            {
                Console.WriteLine("before : " + s);             // ToString()
                s.Translate(new Vertex(10, 10));
                Console.WriteLine("after : " + s);              // ToString()
            }

        }
    }
}